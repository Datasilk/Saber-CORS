# CORS
A vendor plugin for [Saber](https://github.com/Datasilk/Saber) that handles cross-origin requests.

### Prerequisites
* Visual Studio 2017
* [Saber](https://github.com/Datasilk/Saber) ([latest release](https://github.com/Datasilk/Saber/releases))

### Installation
#### For Visual Studio Users
* Clone this repository inside your Saber project within `/App/Vendor/` and name the folder **CORS**
	> NOTE: use `git clone` instead of `git submodule add` since the contents of the Vendor folder is ignored by git
* Copy `/App/Vendor/CORS/config.template.json` to `/App/Vendor/CORS/config.json` and open the file for modification
	* Add at least one URL to the `origins:development` array, e.g. `"https://localhost:7070"`
    * Add at least one URL to the `origins:production` array, e.g. `"https://www.mycoolsite.io"`
* Run `gulp default`

#### For DevOps Users
While using the latest release of [Saber](https://github.com/Datasilk/Saber/releases), do the following:
* Download latest release of [Saber.Vendor.CORS](https://github.com/Datasilk/Saber-CORS/releases)
* Extract all files & folders from either `win-x64` or `linux-x64` folder to Saber's `/Vendors/` folder
* Open the file `/Vendors/CORS/config.json` for modification
	* Add at least one URL to the `origins:development` array, e.g. `"https://localhost:7070"`
    * Add at least one URL to the `origins:production` array, e.g. `"https://www.mycoolsite.io"`

### Publish
* run command `./publish.bat`
* 
#### Usage
When a 3rd-party website makes Web API calls to your website on a public domain other than your own domain, this plugin will authorize access via **CORS** as long as you include the 3rd-party domain within the *config.json* file.