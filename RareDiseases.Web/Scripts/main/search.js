var search = (function () {
    return {
        strip: function (html) {
            var tmp = document.createElement("DIV");
            tmp.innerHTML = html;
            return tmp.textContent || tmp.innerText || "";
        },

        initSearch: function (tboxSelector, linkSelector) {
            var $tboxSearch = $(tboxSelector),
                $link = $(linkSelector);

            if ($tboxSearch.length > 0 && $link.length > 0) {
                $link.click(function () {
                    var searchTerm = search.strip($tboxSearch.val()).trim(),
                        searchUrl = $('body').data('search-page-url');

                    if (searchTerm !== '' && searchTerm !== $tboxSearch.attr('placeholder') && searchUrl != null) {
                    	window.location.href = searchUrl + (searchUrl.indexOf('?') > -1 ? "&q=" : "?q=") + escape(searchTerm);
                    }

                    return false;
                });

                $tboxSearch.keypress(function (event) {
                    var $self = $(this),
                        searchTerm = $self.val().trim();

                    if (event.keyCode === 13 && searchTerm !== '' && searchTerm !== $self.attr('placeholder')) {
                        event.stopPropagation();
                        $link.click();

                        return false;
                    } else if (event.keyCode === 13) {
                        return false;
                    }

                    return true;
                });
            }
        }
    }
}());