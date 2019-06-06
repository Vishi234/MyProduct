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
function toggleIcon(e) {
    $(e.target)
        .prev('.panel-heading')
        .find(".more-less")
        .toggleClass('glyphicon-plus glyphicon-minus');
}
$('.panel-group').on('hidden.bs.collapse', toggleIcon);
$('.panel-group').on('shown.bs.collapse', toggleIcon);