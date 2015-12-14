jQuery(function ($) {
    $('#ban_user_btn').click(function () {
        var banResultLabel = $('#ban_result');
        var isBan = $('#userBanValue').val();

        var databind = isBan;

        e.preventDefault();
        $.ajax({
            url: '@Url.Action("Freeze", "CreditTypes")',
            type: 'POST',
            data: { creditTypeId: $(this).attr('href'), isActive: databind },
            success: function (data) {
                var btn = $('#ban_user_btn');

                banResultLabel.text(data.msg);
                banResultLabel.fadeTo(10, 1);
                if (data.result) {
                    banResultLabel.addClass('alert-success');
                    banResultLabel.removeClass('alert-danger');

                    if (data.active) {
                        btn.addClass('user-banned');
                        btn.removeClass('user-unban');
                        btn.prop('value', 'set active');
                        $('#userBanValue').html("false");
                        isBan = false;
                    } else {
                        btn.addClass('user-unban');
                        btn.removeClass('user-banned');
                        btn.prop('value', 'set not active');
                        $('#userBanValue').html("true");
                        isBan = true;
                    }

                } else {
                    banResultLabel.addClass('alert-danger');
                    banResultLabel.removeClass('alert-success');
                }

                banResultLabel.fadeTo(5000, 0);
            },
            error: function (xhr, textStatus, errorThrown) {
                alert('request failed');

                banResultLabel.text('error connect to server');
                banResultLabel.fadeTo(10, 1);
                banResultLabel.addClass('alert-danger');
                banResultLabel.removeClass('alert-success');
            }
        });
    });
});