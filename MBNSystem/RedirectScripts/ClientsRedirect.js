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
                    $('body').find('.container').html($(data).find('#about-content').html());
                    $('body').find('.container').animate({
                        marginLeft: "0px",
                        marginRight: "0px",
                        opacity: 1.0
                    }, 700, "swing");
                })
            }
        })
    });

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