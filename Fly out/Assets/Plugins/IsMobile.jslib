var IsMobile = {

	IsMobile: function() {
      return Module.SystemInfo.mobile;
    }
	
}
mergeInto(LibraryManager.library, IsMobile);