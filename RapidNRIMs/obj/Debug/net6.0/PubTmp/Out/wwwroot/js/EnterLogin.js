function onClickEnter() {
    $(document).ready(function () {
        $("#username").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_signin").click();
            }
        });
        $("#email").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_SigninEmail").click();
            }
        });
        $("#password").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_signin").click();
            }
        });
        $("#passwordemail").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_SigninEmail").click();
            }
        });
        $("#sel_language").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_signin").click();
            }
        });
        $("#sel_languageEmail").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_SigninEmail").click();
            }
        });

        $("#instrumentNumber").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_signin").click();
            }
        });

        $(".enter-btn").keyup(function (event) {
            if (event.which === 13) {
                $("#btn_signin").click();
            }
        });

        //$("#btn_signin").click(function () {
        //    alert('clicked!');
        //})
    });
}