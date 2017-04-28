﻿// <copyright file="IPixel.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageSharp.PixelFormats
{
    /// <summary>
    /// Porter Duff Blending composition modes
    /// </summary>
    public enum PixelTransformMode
    {
        /// <summary>
        /// Default blending mode, also known as "Normal" or "Alpha Blending"
        /// </summary>
        Normal,

        /// <summary>
        /// Backdrop + Source
        /// </summary>
        Multiply,

        /// <summary>
        /// Backdrop + Source
        /// </summary>
        Add,

        /// <summary>
        /// Backdrop - Source
        /// </summary>
        Substract,

        /// <summary>
        /// Screen effect
        /// </summary>
        Screen,

        /// <summary>
        /// Darken effect
        /// </summary>
        Darken,

        /// <summary>
        /// Lighten effect
        /// </summary>
        Lighten,

        /// <summary>
        /// Overlay effect
        /// </summary>
        Overlay,

        /// <summary>
        /// Hard light effect
        /// </summary>
        HardLight
    }
}
