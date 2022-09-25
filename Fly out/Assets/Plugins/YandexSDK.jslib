mergeInto(LibraryManager.library, {

	Autorization: function() {
		autorization();
	},

	ShowInterAd: function() {
		showInterAd();
	},
	
	ShowRewardedAd: function() {
		showRewardAd();
	},

	ActivityRTB: function(state)
	{
		activityRTB(state);
	},
	
	RenderRTB: function()
	{
		renderRTB();
	},
	
	RecalculateRTB: function(_width, _height, _left, _top)
	{
		recalculateRTB(
			UTF8ToString(_width),
			UTF8ToString(_height),
			UTF8ToString(_left),
			UTF8ToString(_top));
	}

});