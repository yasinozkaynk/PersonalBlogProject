using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog_Proje.Areas.WriterBlog.TageHelpers
{
    [HtmlTargetElement("blog-list-pager")]
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder builder = new StringBuilder();
            builder.Append("<ul class='pagination'>");
            for (int i = 1; i <=PageCount; i++)
            {
                builder.AppendFormat("<li class='{0}'>");
                builder.AppendFormat("<a href='/WriterBlog/Blog/Index?page={0}'>{2}</a>");
                builder.Append("</li>");
            }
            output.Content.SetHtmlContent(builder.ToString());
            base.Process(context, output);
        }
    }
}
