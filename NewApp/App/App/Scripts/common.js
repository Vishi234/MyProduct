function CallToast(message, flag) {
    var heading = ((flag == 'F') ? "Error" : ((flag == 'V') ? "Information" : "Success"));
    var icon = ((flag == 'F') ? "error" : ((flag == 'V') ? "info" : "success"));
    $.toast({
        heading: heading,
        text: message,
        icon: icon,
        position: 'top-right',
        hideAfter: 3000,
        stack: false
    })

}