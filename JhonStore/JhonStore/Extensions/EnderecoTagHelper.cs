using Microsoft.AspNetCore.Razor.TagHelpers;

namespace JhonStore.Extensions
{
    public class EnderecoTagHelper : TagHelper
    {
        public string SiteEduardo { get; set; } = "desenvolvedor.io";



        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var content = await output.GetChildContentAsync();
            var target = content.GetContent() + SiteEduardo;
            output.Attributes.SetAttribute("href", target);
            output.Content.SetContent(target);
        }
        
    }

}
