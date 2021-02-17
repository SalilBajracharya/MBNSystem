﻿
//------Client Search------//
//$('body').on('change', '.txt-client-search', function () {
//    $('body').find('.btn-client-search').trigger('click');
//})

$('body').on('click', '.btn-client-search', function () {
    var search = $(this).closest('.search-container').find('.txt-client-search').val();
    console.log("Search value : " + search);
    var url = $(this).closest('.search-container').attr('url');
    console.log("url value : " + url);
    $.ajax({
        type: "GET",
        url: url,
        data: { search: search },
        success: function (data) {
            console.log("hi");
            $('body').find('#client-list-table').html($(data).find('#client-list-table').html());
        }
    })
})