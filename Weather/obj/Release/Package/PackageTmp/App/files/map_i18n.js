/**
 * This file is licensed under Creative Commons Zero (CC0)
 * http://creativecommons.org/publicdomain/zero/1.0/
 *
 * Author: http://www.openstreetmap.org/user/Zartbitter
 */

 /**
 * Internationalization of some texts used by the map.
 * @param String key the key of the text item
 * @param String lang the language id
 * @return String the localized text item or the id if there's no translation found
 */
function getI18n(key, lang) {
	var i18n = {
	    en: {
			  maps: 'Maps'
			, layers: 'TileLayer'

			, clouds: 'Clouds'
			, cloudscls: 'Clouds (classic)'
			, precipitation: 'Precipitation'
			, precipitationcls: 'Precipitation (classic)'
			, rain: 'Rain'
			, raincls: 'Rain (classic)'
			, snow: 'Snow'
			, temp: 'Temperature'
			, windspeed: 'Wind Speed'
			, pressure: 'Pressure'
			, presscont: 'Pressure Contour'

			, city: 'Cities'
			, windrose: 'Wind Rose'

			, prefs: 'Preferences'
			, scrollwheel: 'Scrollwheel'
			, on: 'on'
			, off: 'off'
		}
	    
		,

	vn: {
	    maps: 'Bản đồ'
			, layers: 'Lớp bản đồ'
			, clouds: 'Mây'
			, cloudscls: 'Mây (classic)'
			, precipitation: 'Lượng mưa'
			, precipitationcls: 'Lượng mưa (classic)'
			, rain: 'Mưa'
			, raincls: 'Mưa (classic)'
			, snow: 'Tuyết'
			, temp: 'Nhiệt độ'
			, windspeed: 'Tốc độ gió'
			, pressure: 'Áp suất'
			, presscont: 'Đường viền áp suất'

			, city: 'Thành phố'
			, windrose: 'Gió'

			, prefs: 'Yêu thích'
			, scrollwheel: 'Cuộn'
			, on: 'Bật'
			, off: 'Tắt'
	}
	};

	if (typeof i18n[lang] != 'undefined'
			&& typeof i18n[lang][key] != 'undefined') {
		return  i18n[lang][key];
	}
	return key;
}

/**
 * Try to find a language we shoud use. Look for URL parameter or system settings.
 * Restricts to supported languages ('en', 'fr', 'ru', 'de' and some others).
 * @return String language code like 'en', 'fr', 'ru', 'de' or others
 */
function getLocalLanguage() {
	var lang = null;

	// 1. try to read URL parameter 'lang'
	var qs = window.location.search;
	if (qs) {
		if (qs.substring(0, 1) == '?') {
			qs = qs.substring(1)
		}
		var params = qs.split('&')
		for(var i = 0; i < params.length; i++) {
			var keyvalue = params[i].split('=');
			if (keyvalue[0] == 'lang') {
				lang = keyvalue[1];
				break;
			}
		}
	}

	// 2. try to get browser or system language
	if (!lang) {
		var tmp = window.navigator.userLanguage || window.navigator.language;
		lang = tmp.split('-')[0];
	}

	// Use only supported languages, defaults to 'vn'
if (lang != 'en' && lang != 'it' && lang != 'de' && lang != 'fr' && lang != 'ru' && lang != 'nl' && lang != 'ca' && lang != 'es' && lang != 'pt_br' && lang != 'vn') {
		lang = 'vn';
	}
	return lang;
}

