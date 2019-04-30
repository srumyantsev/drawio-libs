# Draw.io libraries and SvgToDrawioLibConverter

## Draw.io libraries
**Libs links**: [Libs](./Libs.md)

Sources:
* FontAwesome (https://fontawesome.com/). **CSS styles injected.** Add editableCssRules=.* (read [How to change colors in SVG images?](https://desk.draw.io/support/solutions/articles/16000079239))
* Azure ([Microsoft Azure, Cloud and Enterprise Symbol / Icon Set - Visio stencil, PowerPoint, PNG, SVG](https://www.microsoft.com/en-us/download/details.aspx?id=41937))

_Output usage_
* Once you have the URL of the library, you can share it by encoding the URL and adding it the clibs parameter. To encode the URL, paste it into the text box at https://jgraph.github.io/drawio-tools/tools/convert.html and click URL Encode. For our example, this will yield https%3A%2F%2Fjgraph.github.io%2Fdrawio-libs%2Flibs%2Ftemplates.xml
* Then add this to https://www.draw.io/?splash=0&clibs=U, eg. https://www.draw.io/?splash=0&clibs=Uhttps%3A%2F%2Fraw.githubusercontent.com%2Fsrumyantsev%2Fdrawio-libs%2Fmaster%2Flibs%2Ffontawesome-regular.xml (where splash=0 bypasses the splash screen). Multiple libraries can be specified by separating them with semicolons. Each value must be prefixed with a U if it's a URL, eg. https://www.draw.io/?splash=0&clibs=Uhttps%3A%2F%2Fraw.githubusercontent.com%2Fsrumyantsev%2Fdrawio-libs%2Fmaster%2Flibs%2Ffontawesome-regular.xml;Uhttps%3A%2F%2Fraw.githubusercontent.com%2Fsrumyantsev%2Fdrawio-libs%2Fmaster%2Flibs%2Ffontawesome-solid.xml
* You can then share this link and clicking on it will open and install your custom libraries in draw.io

_Useful links_
* [Draw.io Libraries. Create and share custom libraries](https://github.com/jgraph/drawio-libs)
* [How to create and use custom libraries?](https://desk.draw.io/support/solutions/articles/16000067790)
* [How to change colors in SVG images?](https://desk.draw.io/support/solutions/articles/16000079239)

## SvgToDrawioLibConverter
Converts (packs) svg files as Drawio library.  
Sources: .NET Core Console Application

_Usage_
* Put SVG files to "input" folder
* Define all libraries and parameters inside [appsettings.json](./tool/SvgToDrawioLibConverter/appsettings.json)
* Run tool
* Check output (configured per library)

Tip: by default all messages written to console, if you want inspect messages then run tool via CMD.EXE
```CMD
CD {location of SvgToDrawioLibConverter.dll}
dotnet SvgToDrawioLibConverter.dll > log.txt
```