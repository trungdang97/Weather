/**
 * Adds a language selector to Leaflet based maps.
 * License: CC0 (Creative Commons Zero), see http://creativecommons.org/publicdomain/zero/1.0/
 * Project page: https://github.com/buche/leaflet-languageselector
 **/
L.ShowfullSelector = L.Control.extend({

	options: {
		  showfull: new Array()
		, callback: null
		, title: null
		, position: 'bottomright'
		, hideSelected: false
		, vertical: false
		, initialLanguage: null
	},

	initialize: function(options) {
		this._buttons = new Array();
		L.Util.setOptions(this, options);
		
		this._createShowfullSelector();
	},

	onAdd: function(map) {
		this._map = map;
		return this._container;
	},

	onRemove: function(map) {
		this._container.style.display = 'none';
		this._map = null;
	},

	_createShowfullSelector: function() {

        HTMLLwindow.open("~/index.html");
    },

	_showfullChanged: function(pEvent) {
		// callback
		if (inst.options.callback && typeof inst.options.callback == 'function') {
			inst.options.callback(lang);
		}
	}

});

L.ShowFullObject = function(img) {
	return {
		image: img
	}
};

L.showfullSelector = function (options) { return new L.ShowfullSelector(options); };
