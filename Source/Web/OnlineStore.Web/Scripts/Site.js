
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#selectedImage')
                .attr('src', e.target.result)
                .width(width)
                .height(heigh);
        };

        reader.readAsDataURL(input.files[0]);
    }
}