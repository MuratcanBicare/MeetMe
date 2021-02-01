
var previewImageInitialSrc = null;
var previewImageinitialVisible = null;
//data-preview-image-target="img-id"
$("[data-preview-image-target]").on("input", function (event) {
    var input = this;
    var targetImg = $(this).data("preview-image-target");
    var img = $(targetImg)[0];
    if (previewImageinitialVisible == null)
        previewImageinitialVisible = img.style.display != "none";
    if (previewImageInitialSrc == null) {
        previewImageInitialSrc = img.src;
    }

    //https://stackoverflow.com/questions/4459379/preview-an-image-before-it-is-uploaded
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        //reader okumayı bitirdiğinde
        reader.onload = function (e) {
            // okunan resmi <img ...> elementi üzerinde göster
            img.src = e.target.result;
            img.style.display = "inline";
        };

        reader.readAsDataURL(input.files[0]);
    }
    else {
        if (previewImageinitialVisible) {
            img.src = previewImageInitialSrc;
            //img.style.display = "inline";
        } else {
            img.style.display = "none";
        }
    }
});

$("[data-slugify-target]").on("focusout", function () {
    var target = $(this).data("slugify-target");
    var text = $(this).val();

    $.ajax({
        type: "POST",
        url: baseUrl + "Admin/Slug/Generate",
        data: { text: text },
        success: function (data) {
            if (!$(target).val()) {
                $(target).val(data);
            }
        }
    })
});