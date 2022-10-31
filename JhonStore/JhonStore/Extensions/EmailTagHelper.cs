﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace JhonStore.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + "@" + "joao.io";
            output.Attributes.SetAttribute("href","mailto:"+ target); ;
            output.Content.SetContent(target);
        }
    }
}
