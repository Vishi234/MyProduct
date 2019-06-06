function CallToast(message, flag) {
    $.toast({
        heading: ((flag == 'F') ? "Error" : "Success"),
        text: message,
        icon: ((flag == 'F') ? 'error' : 'success'),
        position: 'top-right',
        hideAfter: 3000,
        stack: false
    })

}