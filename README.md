# Draw.io libraries and SvgToDrawioLibConverter

## Draw.io libraries
_Output_
* FontAwesome (https://fontawesome.com/). **CSS styles injected.** Add editableCssRules=.* (read [How to change colors in SVG images?](https://desk.draw.io/support/solutions/articles/16000079239))
  * [fontawesome-brands.xml](./libs/fontawesome-brands.xml)
  * [fontawesome-regular.xml](./libs/fontawesome-regular.xml)
  * [fontawesome-solid.xml](./libs/fontawesome-solid.xml)
* Azure ([Microsoft Azure, Cloud and Enterprise Symbol / Icon Set - Visio stencil, PowerPoint, PNG, SVG](https://www.microsoft.com/en-us/download/details.aspx?id=41937))
  * [azure-bonus-azureportaliconsdump-general-color-statusbadge.xml](./libs/azure-bonus-azureportaliconsdump-general-color-statusbadge.xml)
  * [azure-bonus-azureportaliconsdump-general-color.xml](./libs/azure-bonus-azureportaliconsdump-general-color.xml)
  * [azure-bonus-azureportaliconsdump-general-monochrome-html-editor.xml](./libs/azure-bonus-azureportaliconsdump-general-monochrome-html-editor.xml)
  * [azure-bonus-azureportaliconsdump-general-monochrome-shell-jumpbar.xml](./libs/azure-bonus-azureportaliconsdump-general-monochrome-shell-jumpbar.xml)
  * [azure-bonus-azureportaliconsdump-general-monochrome-shell-part-sizes.xml](./libs/azure-bonus-azureportaliconsdump-general-monochrome-shell-part-sizes.xml)
  * [azure-bonus-azureportaliconsdump-general-monochrome-shell.xml](./libs/azure-bonus-azureportaliconsdump-general-monochrome-shell.xml)
  * [azure-bonus-azureportaliconsdump-general-monochrome.xml](./libs/azure-bonus-azureportaliconsdump-general-monochrome.xml)
  * [azure-bonus-azureportaliconsdump-logos.xml](./libs/azure-bonus-azureportaliconsdump-logos.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-basel-baselstatus-another.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-basel-baselstatus-another.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-basel-baselstatus.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-basel-baselstatus.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-basel-services.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-basel-services.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-basel-status.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-basel-status.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-basel.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-basel.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-controls.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-controls.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-emoticon.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-emoticon.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-jumpbar.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-jumpbar.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-new-new.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-new-new.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-new.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-new.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-part-sizes.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-part-sizes.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-polychromatic.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-polychromatic.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style-statusbadge.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style-statusbadge.xml)
  * [azure-bonus-azureportaliconsdump-monostroke-win10style.xml](./libs/azure-bonus-azureportaliconsdump-monostroke-win10style.xml)
  * [azure-bonus-azureportaliconsdump-new_2016_09.xml](./libs/azure-bonus-azureportaliconsdump-new_2016_09.xml)
  * [azure-bonus-azureportaliconsdump-service_related-billing.xml](./libs/azure-bonus-azureportaliconsdump-service_related-billing.xml)
  * [azure-bonus-azureportaliconsdump-service_related.xml](./libs/azure-bonus-azureportaliconsdump-service_related.xml)
  * [azure-symbols-cne_cloud-png.xml](./libs/azure-symbols-cne_cloud-png.xml)
  * [azure-symbols-cne_cloud-svg.xml](./libs/azure-symbols-cne_cloud-svg.xml)
  * [azure-symbols-cne_deprecated.xml](./libs/azure-symbols-cne_deprecated.xml)
  * [azure-symbols-cne_enterprise.xml](./libs/azure-symbols-cne_enterprise.xml)
  * [azure-symbols-cne_generalsymbols.xml](./libs/azure-symbols-cne_generalsymbols.xml)
  * [azure-symbols-cne_intune.xml](./libs/azure-symbols-cne_intune.xml)
  * [azure-symbols-cne_othermicrosoftprod.xml](./libs/azure-symbols-cne_othermicrosoftprod.xml)
  * [azure-symbols-cne_system_center.xml](./libs/azure-symbols-cne_system_center.xml)
  * [azure-symbols-cne_vms_by_function.xml](./libs/azure-symbols-cne_vms_by_function.xml)

_Output usage_
* Once you have the URL of the library, you can share it by encoding the URL and adding it the clibs parameter. To encode the URL, paste it into the text box at https://jgraph.github.io/drawio-tools/tools/convert.html and click URL Encode. For our example, this will yield https%3A%2F%2Fjgraph.github.io%2Fdrawio-libs%2Flibs%2Ftemplates.xml
* Then add this to https://www.draw.io/?splash=0&clibs=U, eg. https://www.draw.io/?splash=0&clibs=Uhttps%3A%2F%2Fjgraph.github.io%2Fdrawio-libs%2Flibs%2Ftemplates.xml (where splash=0 bypasses the splash screen). Multiple libraries can be specified by separating them with semicolons. Each value must be prefixed with a U if it's a URL, eg. https://www.draw.io/?splash=0&clibs=Uhttps%3A%2F%2Fjgraph.github.io%2Fdrawio-libs%2Flibs%2Fun-ocha-icons-bluebox.xml;Uhttps%3A%2F%2Fjgraph.github.io%2Fdrawio-libs%2Flibs%2Fun-ocha-icons.xml
* You can then share this link and clicking on it will open and install your custom libraries in draw.io

_Useful links_
* [Draw.io Libraries. Create and share custom libraries](https://github.com/jgraph/drawio-libs)
* [How to create and use custom libraries?](https://desk.draw.io/support/solutions/articles/16000067790)
* [How to change colors in SVG images?](https://desk.draw.io/support/solutions/articles/16000079239)

## SvgToDrawioLibConverter
Converts (packs) svg files as Drawio library.

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