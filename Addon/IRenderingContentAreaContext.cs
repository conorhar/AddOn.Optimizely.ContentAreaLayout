﻿using System;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using AddOn.Optimizely.ContentAreaLayout.Context;
using AddOn.Optimizely.ContentAreaLayout.Models;

namespace AddOn.Optimizely.ContentAreaLayout
{
    public interface IRenderingContentAreaFallbackContext
    {
        /// <summary>
        /// The beginning of a Context. This is called when a content area does not include any LayoutBlocks
        /// </summary>
        void ContainerOpen(IHtmlHelper htmlHelper, BlockRenderingMetadata blockMetadata);
        
        /// <summary>
        /// Area Context is over, clean up any open tags.
        /// </summary>
        void ContainerClose(IHtmlHelper htmlHelper);
    }
    
    public interface IRenderingContentAreaContext
    {
        /// <summary>
        /// Render any opening tags prior to the rendering of an item.
        /// (For example, in bootstrap, opening row div if not already there, opening column for each item.)
        /// </summary>
        void ItemOpen(IHtmlHelper htmlHelper, BlockRenderingMetadata blockMetadata);

        /// <summary>
        /// Render any closing tags after an item
        /// (For example, in bootstrap, closing column for each item.)
        /// </summary>
        void ItemClose(IHtmlHelper htmlHelper);

        RenderingProcessorAction RenderItem(IHtmlHelper htmlHelper, ContentAreaItem current, Action renderItem);

        /// <summary>
        /// The beginning of a Context. This is called whether the context contains any items or not.
        /// </summary>
        void ContainerOpen(IHtmlHelper htmlHelper, BlockRenderingMetadata blockMetadata);
        
        /// <summary>
        /// Area Context is over, clean up any open tags.
        /// </summary>
        void ContainerClose(IHtmlHelper htmlHelper);

        /// <summary>
        /// Return true if this IContentAreaContext is capable of containing the childContext.
        /// Return false and this context will be closed a new context will be started for the
        /// childContext.
        /// </summary>
        bool CanContain(IRenderingContentAreaContext childContext);

        /// <summary>
        /// Return true if this IContentAreaContext is capable of living under the parentContext.
        /// </summary>
        bool CanNestUnder(IRenderingContentAreaContext parentContext);

        IRenderingContentAreaContext ParentContext { get; set; }
    }
}