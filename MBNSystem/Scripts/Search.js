
//------Client Search------//
//$('body').on('change', '.txt-client-search', function () {
//    $('body').find('.btn-client-search').trigger('click');
//})

$('body').on('click', '.btn-client-search', function () {
    var search = $(this).closest('.search-container').find('.txt-client-search').val();
    var url = $(this).closest('.search-container').attr('url');
    $.ajax({
        type: "GET",
        url: url,
        data: { search: search },
        success: function (data) {
            $('body').find('#client-list-table').html($(data).find('#client-list-table').html());
        }
    })
})

//------User Search------//
$('body').on('click', '.btn-user-search', function () {
    var search = $(this).closest('.search-container').find('.txt-user-search').val();
    var url = $(this).closest('.search-container').attr('url');
    $.ajax({ 
        type: "GET",
        url: url,
        data: { search: search },
        success: function (data) {
            $('body').find('#user-list-table').html($(data).find('#user-list-table').html());
        }
    })
})

 