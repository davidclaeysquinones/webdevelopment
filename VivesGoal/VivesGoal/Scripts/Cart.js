
document.ready = function() {
    $(document).ready(function() {
        console.log('ready');
        $('#dropdown').hover(function () {
            console.log("dropdown");
            $('#dropdown').css("color", "#E4F5E4");
            $('#dropdown').css("text-decoration-color", "#E4F5E4");
            $('.item-info').css("color", "#E4F5E4");
            $('.item-info').css("text-decoration-color", "#E4F5E4");
            $('.item-info span').css("color", "#E4F5E4");
            $('.item-info span').css("text-decoration-color", "#E4F5E4");
            $('.glyphicon.glyphicon-plus').css('color', '#000000');
            $('.glyphicon.glyphicon-minus').css('color', '#000000');
            $('.btn-danger').css('color', '#000000');
        });

        $('.btn.btn-default.btn-xs.pull-right.glyphicon.glyphicon-minus').off().click(function () {
            var wedstrijd = $(this).attr('data-wedstrijd');
            console.log(wedstrijd);
            var vak = $(this).attr('data-vak');
            console.log(vak);
            console.log('click minus');
            $('.btn.btn-default.btn-xs.pull-right.glyphicon.glyphicon-minus').off();
            $.ajax({
                url: '/ShoppingCart/ChangeAmount?wedstrijdId=' + wedstrijd + '&vakId=' + vak + '&change=-1',
                dataType: 'html',
                success: function (data) {
                    $('#shoppingcartcontainer').html(data);
                    console.log('ajax loaded');
                }
            });

        });

        $('.btn.btn-default.btn-xs.pull-right.glyphicon.glyphicon-plus').off().click(function () {
            var wedstrijd = $(this).attr('data-wedstrijd');
            console.log(wedstrijd);
            var vak = $(this).attr('data-vak');
            console.log(vak);
            console.log('click plus');
            $('.btn.btn-default.btn-xs.pull-right.glyphicon.glyphicon-minus').off();
            $.ajax({
                url: '/ShoppingCart/ChangeAmount?wedstrijdId=' + wedstrijd + '&vakId=' + vak + '&change=+1',
                dataType: 'html',
                success: function (data) {
                    $('#shoppingcartcontainer').html(data);
                    console.log('ajax loaded');

                }
            });
        });

        $('.btn.btn-xs.btn-danger.pull-right').off().click(function () {
            var wedstrijd = $(this).attr('data-wedstrijd');
            console.log(wedstrijd);
            var vak = $(this).attr('data-vak');
            console.log(vak);
            console.log('click del');
            $('.btn.btn-default.btn-xs.pull-right.glyphicon.glyphicon-minus').off();
            $.ajax({
                url: '/ShoppingCart/RemoveFromCart?wedstrijdId=' + wedstrijd + '&vakId=' + vak,
                dataType: 'html',
                success: function (data) {
                    $('#shoppingcartcontainer').html(data);
                    console.log('ajax loaded');
                }
            });
        });
    });
};

