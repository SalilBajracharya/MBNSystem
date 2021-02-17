$(document).ready(function () {
    //------------Homepage redirection---------------//
    $('.sidebar').on('click', '#dashboard', function () {
        var redirectTo = $(this).text();
        $.ajax({
            type: "GET",
            url: $(this).attr('url'),
            data: { redirectTo: redirectTo },
            success: function (data) {
                var width = $('body').find('.container').width();
                $('body').find('.container').animate({
                    marginLeft: "-" + width + "px",
                    marginRight: width + "px",
                    opacity: 0.0
                }, 700, "swing", function () {
                    $('body').find('.container').html($(data).find('#home-content').html());
                    $('body').find('.container').animate({
                        marginLeft: "0px",
                        marginRight: "0px",
                        opacity: 1.0
                    }, 700, "swing")
                })
            }
        })
    });

    //------------Clients redirection---------------//

    //ClientList
    $('.sidebar').on('click', '#clientslist', function () {
        var redirectTo = $(this).text();
        $.ajax({
            type: "GET",
            url: $(this).attr('url'),
            data: { redirectTo: redirectTo },
            success: function (data) {
                var width = $('body').find('.container').width();
                $('body').find('.container').animate({
                    marginLeft: "-" + width + "px",
                    marginRight: width + "px",
                    opacity: 0.0
                }, 700, "swing", function () {
                    $('body').find('.container').html($(data).find('#clients-content').html());
                    $('body').find('.container').animate({
                        marginLeft: "0px",
                        marginRight: "0px",
                        opacity: 1.0
                    }, 700, "swing");
                })
            }
        })
    });

    $('body').on('click', '#btn-addclients', function () {
        $.ajax({
            url: "/Clients/_AddClients",
            success: function (data) {
                $('.modal-content').html('');
                $('.modal-content').append(data);

                var form = $('.modal-content-lg').find('#form');

                $(form).removeData("validator");
                $(form).removeData("unobtrusivevalidation");
                $.validator.unobtrusive.parse(form);

                $('.myModal').modal('show');
            }
        })
    })

    $('body').on('click', '#btn-editclients', function () {
        var clientid = $(this).closest('tr').attr('clientid');
        $.ajax({
            method: "GET",
            url: "/Clients/_EditClient",
            data: { clientid : clientid},
            success: function (data) {
                $('.modal-content').html('');
                $('.modal-content').append(data);

                var form = $('.modal-content-lg').find('#form');

                $(form).removeData("validator");
                $(form).removeData("unobtrusivevalidation");
                $.validator.unobtrusive.parse(form);

                $('.myModal').modal('show');
            }
        })
    })

    //------------User redirection---------------//
    $('.sidebar').on('click', '#users', function () {
        var redirectTo = $(this).text();
        var container = $('body').find('.container')
        $.ajax({
            type: "GET", 
            url: $(this).attr('url'),
            data: { redirectTo: redirectTo },
            success: function (data) {
                var width = container.width();
                container.animate({
                    marginLeft: '-' + width + 'px',
                    marginRight: width + 'px',
                    opacity: 0.0
                }, 700, "swing", function () {
                   container.html($(data).find('#users-content').html());
                        container.animate({
                            marginLeft: '0px',
                            marginRight: '0px',
                            opacity: 1.0
                        }, 700, "swing")
                })
            }
        })
    });

    $('body').on('click', '#btn-addusers', function () {
        $.ajax({
            url: "/Accounts/_AddUser",
            success: function (data) {
                $('.modal-content').html('');
                $('.modal-content').append(data);

                var form = $('.modal-content-lg').find('#form');

                $(form).removeData("validator");
                $(form).removeData("unobtrusivevalidation");
                $.validator.unobtrusive.parse(form);

                $('.myModal').modal('show');
            }
        })
    })

     //------------Admin Controls redirection---------------//
    $('.sidebar').on('click', '#usersettings', function () {
        var redirectTo = $(this).text();
        $.ajax({
            type: "GET",
            url: $(this).attr('url'),
            data: { redirectTo: redirectTo },
            success: function (data) {
                var container = $('body').find('.container');
                var width = container.width();
                container.animate({
                    marginLeft: "-" + width + "px",
                    marginRight: width + "px",
                    opacity: 0.0
                }, 700, "swing", function () {
                        container.html($(data).find('#users-content').html());
                        container.animate({
                            marginLeft: '0px',
                            marginRight: '0px',
                            opacity: 1.0
                        }, 700, "swing")
                })
            }
        })
    })


})