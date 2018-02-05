# Конвертор markdown в html или текст для OneScript

Внешняя компонента реализующая возможность преобразования текста в формате Markdown, в обычный текст или текст html из [OneScript](https://github.com/EvilBeaver/OneScript).

Компонента представляет собой обертку над библиотекой [Markdig](https://github.com/lunet-io/markdig).


## Установка

### OneScript
Установка осуществляется простым копированием файлов dll в какую-нибудь папку.

### HTTP-сервисы
Установка осуществляется копированием файлов dll в папку Bin веб-приложения.
Затем, необходимо подключить библиотеку, добавив нижеследующую строку в секцию <appSettings>, файла web.config:

```bsl
<add key="MarkdigMarkdownProcessor" value="attachAssembly" />
```

### 1С:Предприятие
1. Необходимо скопировать файлы dll в какую-нибудь папку.
2. Необходимо зарегистрировать MarkdigMarkdownProcessorCom.dll при помощи утилиты regasm.
3. Для использования в 64-битных операционных системах, необходимо создать COM+ приложение.
 
## Использование

Конфигурирование расширений осуществляется в соответствии с их [строковыми представлениями](https://github.com/lunet-io/markdig/blob/master/src/Markdig/MarkdownExtensions.cs#L476), а также с учетом того факта, что расширения advanced и attributes должны быть последними, в соответствии с [комментарием](https://github.com/lunet-io/markdig/blob/a097247272fbe4e3d14495be4cbf4effd866f04e/src/Markdig/MarkdownExtensions.cs#L79).
В настоящее время доступны нижеследующие расширения:
- common
- advanced
- pipetables (входит в advanced)
- emphasisextras (входит в advanced)
- listextras (входит в advanced)
- hardlinebreak
- footnotes (входит в advanced)
- footers (входит в advanced)
- citations (входит в advanced)
- attributes (входит в advanced, должен быть последним в списке подключаемых расширений) 
- gridtables (входит в advanced)
- abbreviations (входит в advanced)
- emojis
- definitionlists (входит в advanced)
- customcontainers (входит в advanced)
- figures (входит в advanced)
- mathematics (входит в advanced)
- bootstrap
- medialinks (входит в advanced)
- smartypants
- autoidentifiers (входит в advanced)
- tasklists (входит в advanced)
- diagrams (входит в advanced)
- nofollowlinks
- nohtml
- yaml
- nonascii-noescape
- autolinks (входит в advanced)

Более подробное описание расширений можно посмотреть [здесь](https://github.com/lunet-io/markdig#features).

### OneScript

```bsl
// Подключение внешней компоненты не требуется при использовании с http-сервисами,
// т.к. библиотека подключается через web.config
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

```

### 1С:Предприятие

Код, написанный в 1С:Предприятие, за исключением создания COM-объекта является платформеннонезависимым и может быть напрямую перенесен в OneScript.

```bsl
ТекстMarkdown = "This is a text with some *emphasis*";
// Создание COM-объекта является платформо-зависимым
Процессор = Новый COMОбъект("MarkdigMarkdownProcessorCom.MarkdigMarkdownProcessor");
Процессор.ConfigureExtensions("yaml+advanced");
ТекстHtml = Процессор.GetHtmlFromMarkdown(ТекстMarkdown);
```
