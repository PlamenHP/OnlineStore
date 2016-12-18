
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#selectedImage')
                .attr('src', e.target.result)
                .width(ImageWidth)
                .height(ImageHeight);
        };

        reader.readAsDataURL(input.files[0]);
    }
}