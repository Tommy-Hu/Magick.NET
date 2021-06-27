﻿// Copyright Dirk Lemstra https://github.com/dlemstra/Magick.NET.
// Licensed under the Apache License, Version 2.0.

#if NETSTANDARD2_1

using System;
using System.IO;
using System.Threading.Tasks;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
    /// <content />
    public sealed partial class MagickImageCollectionFactory : IMagickImageCollectionFactory<QuantumType>
    {
        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="data">The span of byte to read the image data from.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public IMagickImageCollection<QuantumType> Create(ReadOnlySpan<byte> data)
             => new MagickImageCollection(data);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="data">The span of byte to read the image data from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public IMagickImageCollection<QuantumType> Create(ReadOnlySpan<byte> data, IMagickReadSettings<QuantumType> readSettings)
             => new MagickImageCollection(data, readSettings);

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="file">The file to read the image from.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public async Task<IMagickImageCollection<QuantumType>> CreateAsync(FileInfo file)
        {
            var images = new MagickImageCollection();
            await images.ReadAsync(file).ConfigureAwait(false);

            return images;
        }

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="file">The file to read the image from.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public async Task<IMagickImageCollection<QuantumType>> CreateAsync(FileInfo file, IMagickReadSettings<QuantumType> readSettings)
        {
            var images = new MagickImageCollection();
            await images.ReadAsync(file, readSettings).ConfigureAwait(false);

            return images;
        }

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public async Task<IMagickImageCollection<QuantumType>> CreateAsync(string fileName)
        {
            var images = new MagickImageCollection();
            await images.ReadAsync(fileName).ConfigureAwait(false);

            return images;
        }

        /// <summary>
        /// Initializes a new instance that implements <see cref="IMagickImageCollection{TQuantumType}"/>.
        /// </summary>
        /// <param name="fileName">The fully qualified name of the image file, or the relative image file name.</param>
        /// <param name="readSettings">The settings to use when reading the image.</param>
        /// <returns>A new <see cref="IMagickImageCollection{TQuantumType}"/> instance.</returns>
        /// <exception cref="MagickException">Thrown when an error is raised by ImageMagick.</exception>
        public async Task<IMagickImageCollection<QuantumType>> CreateAsync(string fileName, IMagickReadSettings<QuantumType> readSettings)
        {
            var images = new MagickImageCollection();
            await images.ReadAsync(fileName, readSettings).ConfigureAwait(false);

            return images;
        }
    }
}

#endif
