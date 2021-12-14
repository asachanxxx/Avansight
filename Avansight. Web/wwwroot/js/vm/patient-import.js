console.log("Inside IIFE");

var ctsFunctions = (function () {
    var $form,
        $btnGenaratePatients,
        $iptsamplesize;

    function init() {
        $form = $('.frm-genarate-patient');
        $btnGenaratePatients = $('.btn-gen-patients');
        $iptsamplesize = $('.ipt-sample-size');

        $btnGenaratePatients.click(function (e) {
            console.log("$btnGenaratePatients clicked");
            //validateForm();
        });

    }


    function validateForm() {
        console.log("validateForm", $form);
        $form.submit(function (e) {
            console.log("$form.submit ", e);
            e.preventDefault();
            //    var first_name = $('#first_name').val();
            //    var last_name = $('#last_name').val();
            //    var email = $('#email').val();
            //    var password = $('#password').val();

            //    $(".error").remove();

            //    if (first_name.length < 1) {
            //        $('#first_name').after('<span class="error">This field is required</span>');
            //    }
            //    if (last_name.length < 1) {
            //        $('#last_name').after('<span class="error">This field is required</span>');
            //    }
            //    if (email.length < 1) {
            //        $('#email').after('<span class="error">This field is required</span>');
            //    } else {
            //        var regEx = /^[A-Z0-9][A-Z0-9._%+-]{0,63}@(?:[A-Z0-9-]{1,63}\.){1,125}[A-Z]{2,63}$/;
            //        var validEmail = regEx.test(email);
            //        if (!validEmail) {
            //            $('#email').after('<span class="error">Enter a valid email</span>');
            //        }
            //    }
            //    if (password.length < 8) {
            //        $('#password').after('<span class="error">Password must be at least 8 characters long</span>');
            //    }
            //});

            $form.validate({
                rules: {
                    //samplesize: 'required',
                    //lname: 'required',
                    //user_email: {
                    //    required: true,
                    //    email: true,
                    //},
                    //psword: {
                    //    required: true,
                    //    minlength: 8,
                    //}
                },
                messages: {
                    //samplesize: 'This field is required',
                    //lname: 'This field is required',
                    //user_email: 'Enter a valid email',
                    //psword: {
                    //    minlength: 'Password must be at least 8 characters long'
                    //}
                },
                submitHandler: function (form) {
                    form.submit();
                }
            });

        });
    }
    //function validateForm() {
    //    console.log("validateForm", $form);
    //    $form.validate({

    //        rules: {
    //            samplesize: {
    //                required: true
    //            },
    //            email: {
    //                required: true,
    //                email: true
    //            },
    //            message: {
    //                minlength: 2,
    //                required: true
    //            }
    //        },
    //        messages: {
    //            samplesize: 'This field is required',
    //            lname: 'This field is required',
    //            user_email: 'Enter a valid email',
    //            psword: {
    //                minlength: 'Password must be at least 8 characters long'
    //            }
    //        },
    //        highlight: function (element) {
    //            $(element).closest('.control-group').removeClass('success').addClass('error');
    //        },
    //        success: function (element) {
    //            element.text('OK!').addClass('valid')
    //                .closest('.control-group').removeClass('error').addClass('success');
    //        }


    //    });
    //}
    
    return {
        init,
        validateForm
    }
})();

