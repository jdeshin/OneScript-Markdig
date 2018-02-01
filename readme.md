# Конвертор markdown в html или текст для OneScript

Внешняя компонента реализующая возможность преобразования текста в формате Markdown, в обычный текст или текст html из [OneScript](https://github.com/EvilBeaver/OneScript).

Компонента представляет собой обертку над библиотекой [Markdig](https://github.com/lunet-io/markdig).


## Установка

Установка осуществляется простым копированием файлов dll в какую-нибудь папку.

## Использование

Конфигурирование расширений осуществляется в соответствии с их [строковыми представлениями](https://github.com/lunet-io/markdig), а также с учетом того факта, что расширения advanced и attributes должны быть последними, в соответствии с [комментарием](https://github.com/lunet-io/markdig/blob/a097247272fbe4e3d14495be4cbf4effd866f04e/src/Markdig/MarkdownExtensions.cs#L79). 

```bsl
ПодключитьВнешнююКомпоненту("ПутьКПапкеСDll\MarkdigMarkdownProcessor.dll");

Процессор = Новый MarkdownПроцессорMarkdig;
// Список возможных расширений и их текстовое представление см. выше
Процессор.СконфигурироватьРасширения("yaml+advanced");
СтрокаMarkdown = "This is a text with some *emphasis*";

// Вызов без обработки расширений Markdown
СтрокаHtml = Процессор.ПолучитьHtmlИзMarkdown(СтрокаMarkdown);
СтрокаТекст = Процессор.ПолучитьСтрокуИзMarkdown(СтрокаMarkdown);

Сообщить(СтрокаHtml); // <p>This is a text with some <em>emphasis</em></p>
Сообщить(СтрокаТекст); // 

// Вызов с обработкой расширений, за исключением BootStrap, Emoji, SmartyPants и soft line как hard line breaks
СтрокаHtml = Процессор.ПолучитьHtmlИзMarkdown(СтрокаMarkdown, Истина);
СтрокаТекст = Процессор.ПолучитьСтрокуИзMarkdown(СтрокаMarkdown, Истина);

Сообщить(СтрокаHtml);
Сообщить(СтрокаТекст);
```

