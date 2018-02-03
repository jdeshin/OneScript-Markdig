using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Markdig;

namespace MarkdigMarkdownProcessorCom
{
    [Guid("69A102B2-2BCD-4B53-A601-0B8043468EA5")]
    public interface MarkdigMarkdownProcessorInterface
    {
        [DispId(1)]
        string GetHtmlFromMarkdown(string markdown);
        [DispId(2)]
        string GetStringFromMarkdown(string markdown);
        [DispId(3)]
        void ConfigureExtensions(string extensions = null);
    }

    [Guid("3DF972CF-8C81-41CC-8894-B1FA36BE0207"),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface MarkdigMarkdownProcessorEvents
    {
    }

    [Guid("C015C6C7-B1FE-49ED-BB16-0441651624B4"),
        ClassInterface(ClassInterfaceType.None),
        ComSourceInterfaces(typeof(MarkdigMarkdownProcessorEvents))]
    public class MarkdigMarkdownProcessor : MarkdigMarkdownProcessorInterface
    {
        private MarkdownPipeline _pipeline;

        public MarkdigMarkdownProcessor()
        {
            _pipeline = new MarkdownPipelineBuilder().Build();
        }

        public string GetHtmlFromMarkdown(string markdown)
        {
            return Markdown.ToHtml(markdown, _pipeline);
        }

        /// <summary>
        /// Конфигурирует расширения. Расширения передаются строкой как extension1+extension2+extensionn. atributes должно быть последним т.к. модифицирует другие парсеры
        /// </summary>
        /// <param name="extensions">список расширений в виде строки, разделенной +</param>
        public void ConfigureExtensions(string extensions = null)
        {
            _pipeline = new MarkdownPipelineBuilder().Configure(extensions).Build();
        }

        public string GetStringFromMarkdown(string markdown)
        {
            return Markdown.ToPlainText(markdown, _pipeline);
        }
    }
}
