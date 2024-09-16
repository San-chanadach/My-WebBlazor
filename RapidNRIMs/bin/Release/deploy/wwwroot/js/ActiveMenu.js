function activeMenu() {

    $(document).ready(function () {
        $("#navMenus").on('click', 'a', function () {
            $("#navMenus a.active").removeClass("active");
            // adding classname 'active' to current click li
            $(this).addClass("active");
        });
    });

}