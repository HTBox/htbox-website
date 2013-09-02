    jQuery.validator.setDefaults({
        highlight: function (element, errorClass, validClass) {
            if (element.type === 'radio') {
                this.findByName(element.name).addClass(errorClass).removeClass(validClass);
            } else {
                $(element).addClass(errorClass).removeClass(validClass);
                $(element).closest('.form-group').removeClass('has-success').addClass('has-error');
            }
        },
        unhighlight: function (element, errorClass, validClass) {
            if (element.type === 'radio') {
                this.findByName(element.name).removeClass(errorClass).addClass(validClass);
            } else {
                $(element).removeClass(errorClass).addClass(validClass);
                $(element).closest('.form-group').removeClass('has-error').addClass('has-success');
            }
        }
    });


    $(document).ready(function() {
        $('form').each(function() {
            $(this).find('div.form-group').each(function() {
                if ($(this).find('span.field-validation-error').length > 0  || $(this).find('input.input-validation-error').length > 0) {
                    $(this).addClass('has-error');
                }
            });
        });
    });;