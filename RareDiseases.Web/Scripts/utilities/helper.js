var helper = (function () {
    return {
        getParameterByName: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
                results = regex.exec(location.search);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        },

        getHashParameterByName: function (name) {
            name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
            var regex = new RegExp("[\\#&]" + name + "=([^&#]*)"),
                results = regex.exec(location.hash);
            return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
        },

        initPagination: function (paginationHtmlContent, $appendToElement, callbackFunction) {
            if (paginationHtmlContent !== '') {
            	if ($('#js_pagination').length) {
            		$('#js_pagination').remove();
            	}
            	$appendToElement.append(paginationHtmlContent);

            	$('#js_pagination li a').click(function () {
            		callbackFunction($(this).data('page'));
            	});
            } else if ($('#js_pagination').length) {
                $('#js_pagination').remove();
            }
        }
    }
} ());