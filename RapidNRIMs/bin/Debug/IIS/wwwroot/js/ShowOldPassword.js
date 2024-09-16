
function showValueOldPassword() {
    $(document).ready(function () {
        $(".eye-event-oldpassword").hide();
        $(".toggle-oldpassword").click(function () {
            $(this).toggleClass("fa-eye fa-eye-slash");
            $(".fa-regular fa-eye").hide();
            var input = $($(this).attr("toggle"));
            if (input.attr("type") == "password") {
                input.attr("type", "text");
            } else {
                input.attr("type", "password");
            }
        });
    });
}

function getInputValueOldPassword() {
    $(document).ready(function () {

        // Selecting the input element and get its value 
        
        $(".eye-event-oldpassword").hide();
        var inputVal = document.getElementById("oldpassword").value;
        // Displaying the value
        if (inputVal !== "") {
            $(".eye-event-oldpassword").show();
        } else {
            $(".eye-event-oldpassword").hide();
        }

       
    });

   
}
