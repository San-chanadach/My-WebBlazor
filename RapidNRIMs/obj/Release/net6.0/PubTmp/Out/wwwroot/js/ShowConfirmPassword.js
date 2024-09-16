
function showValueConfirmPassword() {
    $(document).ready(function () {
        $(".eye-event-confirmpassword").hide();
        $(".toggle-confirmpassword").click(function () {
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

function getInputValueConfirmPassword() {
    $(document).ready(function () {

        // Selecting the input element and get its value 
        
        $(".eye-event-confirmpassword").hide();
        var inputVal = document.getElementById("confirmpassword").value;
        // Displaying the value
        if (inputVal !== "") {
            $(".eye-event-confirmpassword").show();
        } else {
            $(".eye-event-confirmpassword").hide();
        }

       
    });

   
}
