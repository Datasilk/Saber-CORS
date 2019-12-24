# CORS
A vendor plugin for [Saber](https://github.com/Datasilk/Saber) that handles cross-origin requests.

### Prerequisites
* Visual Studio 2017
* Clone [Saber](https://github.com/Datasilk/Saber) repository

### Installation
* Clone this repository inside your Saber project within `/App/Vendor/` and name the folder **CORS**
	> NOTE: use `git clone` instead of `git submodule add` since the contents of the Vendor folder is ignored by git
* Copy `/App/Vendor/CORS/config.template.json` to `/App/Vendor/CORS/config.json` and open the file for modification
	* Add at least one URL to the `origins:development` array, e.g. `"https://localhost:5000"`
    * Add at least one URL to the `origins:production` array, e.g. `"https://www.mycoolsite.io"`
* Run `gulp default`

#### Usage
When a 3rd-party website makes Web API calls to your website on a public domain other than your own domain, this plugin will authorize access via **CORS** as long as you include the 3rd-party domain within the *config.json* file.