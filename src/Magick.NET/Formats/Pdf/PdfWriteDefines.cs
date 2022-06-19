﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick.Formats
{
    /// <summary>
    /// Class for defines that are used when a <see cref="MagickFormat.Pdf"/> image is written.
    /// </summary>
    public sealed class PdfWriteDefines : WriteDefinesCreator
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PdfWriteDefines"/> class.
        /// </summary>
        public PdfWriteDefines()
          : base(MagickFormat.Pdf)
        {
        }

        /// <summary>
        /// Gets or sets the author of the pdf document (pdf:author).
        /// </summary>
        public string? Author { get; set; }

        /// <summary>
        /// Gets or sets the creation time of the pdf document (pdf:create-epoch).
        /// </summary>
        public DateTime? CreationTime { get; set; }

        /// <summary>
        /// Gets or sets the creator of the pdf document (pdf:creator).
        /// </summary>
        public string? Creator { get; set; }

        /// <summary>
        /// Gets or sets the keywords of the pdf document (pdf:keywords).
        /// </summary>
        public string? Keywords { get; set; }

        /// <summary>
        /// Gets or sets the modification time of the pdf document (pdf:modify-epoch).
        /// </summary>
        public DateTime? ModificationTime { get; set; }

        /// <summary>
        /// Gets or sets the producer of the pdf document (pdf:producer).
        /// </summary>
        public string? Producer { get; set; }

        /// <summary>
        /// Gets or sets the subject of the pdf document (pdf:subject).
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets or sets the title of the pdf document (pdf:title).
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets the defines that should be set as a define on an image.
        /// </summary>
        public override IEnumerable<IDefine> Defines
        {
            get
            {
                if (Author?.Length > 0)
                    yield return CreateDefine("author", Author);

                if (CreationTime is not null)
                    yield return CreateDefine("create-epoch", ToUnixTimeSeconds(CreationTime.Value));

                if (Creator?.Length > 0)
                    yield return CreateDefine("creator", Creator);

                if (Keywords?.Length > 0)
                    yield return CreateDefine("keywords", Keywords);

                if (ModificationTime is not null)
                    yield return CreateDefine("modify-epoch", ToUnixTimeSeconds(ModificationTime.Value));

                if (Producer?.Length > 0)
                    yield return CreateDefine("producer", Producer);

                if (Subject?.Length > 0)
                    yield return CreateDefine("subject", Subject);

                if (Title?.Length > 0)
                    yield return CreateDefine("title", Title);
            }
        }

        private static long ToUnixTimeSeconds(DateTime value)
        {
            var dateTimeOffset = (DateTimeOffset)value.ToUniversalTime();
#if NET20
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return (long)(dateTimeOffset - epoch).TotalSeconds;
#else
            return dateTimeOffset.ToUnixTimeSeconds();
#endif
        }
    }
}
