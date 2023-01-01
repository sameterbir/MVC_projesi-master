//kategori işlemleri 
$(document).on("click", "#ktgEkle", async function () {
    
    const { value: formValues } = await Swal.fire({

        title: 'Kategori Ekle',
        html: '<input id="ktgAd" class="swal2-input">'
    })

    //ktg ekler

        var ktgAd = $("#ktgAd").val();
        $.ajax({
            type: 'Post',
            url: '/Kategori/EkleJson',
            data: { "ktgAd": ktgAd },
            dataType: 'Json',
            success: function (data) {
                var ktgId =   data.Result.Id ;
                var ktgAd = '<td>' + data.Result.Ad + '</td>';
                var kitapAdet = "<td>0</td>";
                var guncelleButon = "<td> <button class='guncelle btn btn-custom' value='"+ ktgId +"' >Güncelle</button></td>";
                var silButon = "<td> <button class='sil btn btn-danger' value='" + ktgId + "' >Sil</button></td>";
                $("#example tbody").prepend('<tr>' + ktgAd + kitapAdet + guncelleButon + silButon + '</tr>');

                Swal.fire({
                    type: 'success',
                    title: 'Kategori Eklendi',
                    text: 'İşlem Başarıyla Gerçekleşti'
                });

            },
            error: function () {
                Swal.fire({
                    type: 'Error',
                    title: 'Kategori Eklenmedi',
                    text: 'Bir Sorun İle Karşılaşıldı...'
                });
            }
        });
    
});

$(document).on("click", ".guncelle", async function () {
    var ktgId = $(this).val();
    var ktgAdTd = $(this).parent("td").parent("tr").find("td:first");
    var ktgAd = ktgAdTd.html();
    const { value: formValues } = await Swal.fire({

        title: 'Kategori Güncelle',
        html: '<input id="ktgAd" value="' + ktgAd +'" class="swal2-input">'
    })

    ktgAd = $("#ktgAd").val();
        $.ajax({
            type: 'Post',
            url: '/Kategori/GuncelleJson',
            data: { "ktgId": ktgId , "ktgAd": ktgAd },
            dataType: 'Json',
            success: function (data) {
                ktgAdTd.html(ktgAd);
                if (data == "1") {
                    Swal.fire({
                        type: 'success',
                        title: 'Kategori Güncellendi',
                        text: 'İşlem Başarıyla Gerçekleşti'
                    });
                }
                else {
                    Swal.fire({
                        type: 'Error',
                        title: 'Kategori Güncellenmedi',
                        text: 'Bir Sorun İle Karşılaşıldı...'
                    });
                    }              
            },
            error: function () {
                Swal.fire({
                    type: 'Error',
                    title: 'Kategori Güncellenmedi',
                    text: 'Bir Sorun İle Karşılaşıldı...'
                });
            }
        });
    

});

$(document).on("click", ".sil", async function () {
    var tr = $(this).parent("td").parent("tr");
    var ktgId = $(this).val();
    $.ajax({
        type: 'Post',
        url: '/Kategori/SilJson',
        data: { "ktgId": ktgId },
        dataType: 'Json',
        success: function (data) {
         
            if (data == "1") {
                tr.remove();
                Swal.fire({
                    type: 'success',
                    title: 'Kategori Silindi',
                    text: 'İşlem Başarıyla Gerçekleşti'
                });
            }
            else {
                Swal.fire({
                    type: 'Error',
                    title: 'Kategori Silinemedi',
                    text: 'Bir Sorun İle Karşılaşıldı...'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'Error',
                title: 'Kategori Silinemedi',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }
    });
});
//kategori işlemleri son

//Yazar işlemleri
$(document).on("click", "#yazarEkle", async function () {
    const { value: formValues } = await Swal.fire({

        title: 'Yazar Ekle',
        html: '<input id="yzrAd" class="swal2-input">'
    })



    var yzrAd = $("#yzrAd").val();
    $.ajax({
        type: 'Post',
        url: '/Yazar/EkleJson',
        data: { "yzrAd": yzrAd },
        dataType: 'Json',
        success: function (data) {
            var yzrId = data.Result.Id;
            var yzrAd = '<td>' + data.Result.YazarAdi + '</td>';
            var kitapAdet = "<td>0</td>";
            var guncelleButon = "<td> <button class='guncelle btn btn-custom' value='" + yzrId + "' >Güncelle</button></td>";
            var silButon = "<td> <button class='sil btn btn-danger' value='" + yzrId + "' >Sil</button></td>";
            $("#example tbody").prepend('<tr>' + yzrAd + kitapAdet + guncelleButon + silButon + '</tr>');

            Swal.fire({
                type: 'success',
                title: 'Yazar Eklendi',
                text: 'İşlem Başarıyla Gerçekleşti'
            });

        },
        error: function () {
            Swal.fire({
                type: 'Error',
                title: 'Yazar Eklenmedi',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }
    });

});

$(document).on("click", ".yazarSil", async function () {
    var tr = $(this).parent("td").parent("tr");
    var yazarId = $(this).val();
    $.ajax({
        type: 'Post',
        url: '/Yazar/SilJson',
        data: { "yazarId": yazarId },
        dataType: 'Json',
        success: function (data) {

            if (data == "1") {
                tr.remove();
                Swal.fire({
                    type: 'success',
                    title: 'Yazar Silindi',
                    text: 'İşlem Başarıyla Gerçekleşti'
                });
            }
            else {
                Swal.fire({
                    type: 'Error',
                    title: 'Yazar Silinemedi',
                    text: 'Bir Sorun İle Karşılaşıldı...'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'Error',
                title: 'Yazaar Silinemedi',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }
    });
});

$(document).on("click", ".yazarguncelle", async function () {
    var yzrId = $(this).val();
    var yzrAdTd = $(this).parent("td").parent("tr").find("td:first");
    var yzrAd = yzrAdTd.html();
    const { value: formValues } = await Swal.fire({

        title: 'Yazar Güncelle ',
        html: '<input id="yzrAd" value="' + yzrAd + '" class="swal2-input">'
    })
    // txt e boşluk yaıznca patlıyor  ve yeni eklenen karakter silinip güncellenmiyor
    yzrAd = $("#yzrAd").val();
    $.ajax({
        type: 'Post',
        url: '/Yazar/GuncelleJson',
        data: { "yzrId": yzrId, "yzrAd": yzrAd },
        dataType: 'Json',
        success: function (data) {
            yzrAdTd.html(yzrAd);
            if (data == "1") {
                Swal.fire({
                    type: 'success',
                    title: 'Yazar Güncellendi',
                    text: 'İşlem Başarıyla Gerçekleşti'
                });
            }
            else {
                Swal.fire({
                    type: 'Error',
                    title: 'Yazar Güncellenmedi',
                    text: 'Bir Sorun İle Karşılaşıldı...'
                });
            }
        },
        error: function () {
            Swal.fire({
                type: 'Error',
                title: 'Yazar Güncellenmedi',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }
    });


});
//Yazar İşlemleri Son

//Kitap İŞlemleri // düzeltilecek
$(document).on("click", "#kategoriEkle", async function () {    
    var secilenKategoriAd = $("#kategoriler").val();
    if (secilenKategoriAd != null && secilenKategoriAd != "" ) {
        var secilenId = $("#kategoriler option:selected").attr("data-id");
        $("#eklenenKategoriler").append('<div  id="' + secilenId + '"class="col-md-1 bg-primary kategoriSil" style="margin-right:2px; margin-bottom:2px;  ">' + secilenKategoriAd + '</div>');
        $("#kategoriler option:selected").remove();
    }
  
    });

$(document).on("click", ".kategoriSil", async function () {
    var id = $(this).attr("id");
    var kategoriAd = $(this).html();
    $("#kategoriler").append(' <option data-id="' + id + '">' + kategoriAd + '</option>');
    $(this).remove();

});

$(document).on("click", "#kitapKaydet",  function () {
    var degerler = {
        kategoriler: [],
        yazar : $("#yazar option:selected").attr("data-id"),
        kitapAd : $("#kitapAd").val(),
        kitapAdet : $("#kitapAdet").val(),
        siraNo: $("#siraNo").val()

    };

    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });


    $.ajax({

        type: 'Post',
        url: '/Kitap/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'kitap eklendi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else if("bosOlamaz"){
                Swal.fire({
                    type: 'error',
                    title: 'kitap Eklenmedi!',
                    text: 'Boş alanları lütfen doldurun...!'
                });
            }
            
        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: 'Kitap Eklenmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});

$(document).on("click", ".kitapSil", function () {
    
    Swal.fire({
        title: '  Siliniyor... ',
        text: "Kitabı Gerçekten Silmek İstiyormusun ?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç'
    }).then((result) => {
        if (result.isConfirmed) {
            var kitapId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: 'Kitap/SilJson',
                data: { "kitapId": kitapId },
                dataType: 'Json',
                success : function (data) {
                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                           type :  'succes',
                           title :  'Kitap Silindi',
                           text: 'İşlem Başarıyla Gerçekleşti'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Kitap Silinmedi',
                            text: 'Veri Tabanında Bir Sorun Oluştu'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'Kitap Silinmedi',
                        text: 'Bir Sorun Oluştu'
                    });
                }

            
            });
        }
    })


});

$(document).on("click", "#kitapGuncelle", function () {
    var degerler = {
        kategoriler: [],
        yazar: $("#yazar option:selected").attr("data-id"),
        kitapAd: $("#kitapAd").val(),
        kitapAdet: $("#kitapAdet").val(),
        siraNo: $("#siraNo").val(),
        kitapId: $(this).attr("data-id")

    };

    $("#eklenenKategoriler div").each(function () {
        var id = $(this).attr("id");
        degerler.kategoriler.push(id);
    });


    $.ajax({

        type: 'Post',
        url: '/Kitap/GuncelleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'kitap Güncellendi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'kitap Güncellenmedi!',
                    text: 'Boş alanları lütfen doldurun...!'
                });
            }

        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: 'Kitap Güncellenmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});

$(document).on("click", "#kitapVer", function () {
    var degerler = {
        uyeId: $("#uyeId option:selected").attr("data-id"),
        kitapId: $("#kitapId option:selected").attr("data-id"),
        getirecegiTarih: $("#getirecegiTarih").val(),


    };


    $.ajax({

        type: 'Post',
        url: '/OduncKitap/KitapVerJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'Kitap Verildi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else {
                Swal.fire({
                    type: 'Error',
                    title: ' Kitap Verilmedi ',
                    text: 'Veritabanına Eklenirken Bir Sorun İle Karşılaşıldı...'
                });
            }


        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: ' Kitap Verilmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});

$(document).on("click", "#verilenKitabiGuncelle", function () {
    var degerler = {
        oduncKitapId: $(this).attr("data-id"),
        uyeId: $("#uyeId option:selected").attr("data-id"),
        kitapId: $("#kitapId option:selected").attr("data-id"),
        getirecegiTarih: $("#getirecegiTarih").val()


    };


    $.ajax({

        type: 'Post',
        url: '/OduncKitap/VerilenKitabiGuncelleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'Verilen Kitap Güncellendi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else {
                Swal.fire({
                    type: 'Error',
                    title: 'Verilen Kitap Güncellenmedi ',
                    text: 'Veritabanına Eklenirken Bir Sorun İle Karşılaşıldı...'
                });
            }


        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: 'Verilen Kitap Güncellenmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});
//Kitap İşlemleri Son


//Üye İşlemleri
$(document).on("click", "#uyeKaydet", function () {
    var degerler = {     
        uyeAd: $("#uyeAd").val(),
        uyeSoyad: $("#uyeSoyad").val(),
        uyeTc: $("#uyeTc").val(),
        uyeTel: $("#uyeTel").val()

    };
    $.ajax({

        type: 'Post',
        url: '/Uye/EkleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'Üye eklendi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Üye Eklenmedi!',
                    text: 'Boş alanları lütfen doldurun...!'
                });
            }

        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: 'Üye Eklenmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});

$(document).on("click", "#uyeSil",  function () {

    Swal.fire({
        title: '  Siliniyor... ',
        text: "Üyeyi Gerçekten Silmek İstiyormusun ?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'Vazgeç'
    }).then((result) => {
        if (result.value) {
            var uyeId = $(this).val();
            var tr = $(this).parent("td").parent("tr");

            $.ajax({
                type: 'Post',
                url: 'Uye/SilJson',
                data: { "uyeId": uyeId },
                dataType: 'Json',
                success: function (data) {
                    if (data == "1") {
                        tr.remove();
                        Swal.fire({
                            type: 'succes',
                            title: 'Üye Silindi',
                            text: 'İşlem Başarıyla Gerçekleşti'
                        });
                    }
                    else {
                        Swal.fire({
                            type: 'error',
                            title: 'Üye Silinmedi',
                            text: 'Veri Tabanında Bir Sorun Oluştu'
                        });
                    }
                },
                error: function () {
                    Swal.fire({
                        type: 'error',
                        title: 'Üye Silinmedi',
                        text: 'Bir Sorun Oluştu'
                    });
                }


            });
        }
    })


});

$(document).on("click", "#uyeGuncelle", function () {
    var degerler = {
        uyeAd: $("#uyeAd").val(),
        uyeSoyad: $("#uyeSoyad").val(),
        uyeTc: $("#uyeTc").val(),
        uyeTel: $("#uyeTel").val(),
        uyeId: $(this).attr("data-id")

    };

 

    $.ajax({

        type: 'Post',
        url: '/Uye/GuncelleJson',
        data: JSON.stringify(degerler),
        dataType: 'JSON',
        contentType: 'application/json;charset=utf-8',
        success: function (gelenDeg) {
            if (gelenDeg == "1") {
                Swal.fire({
                    type: 'succes',
                    title: 'Üye Güncellendi',
                    text: 'İşlem Başarıyla  Gerçekleşti ...'
                });

            }
            else if ("bosOlamaz") {
                Swal.fire({
                    type: 'error',
                    title: 'Üye Güncellenmedi!',
                    text: 'Boş alanları lütfen doldurun...!'
                });
            }

        },
        error: function (gelenDeg) {
            Swal.fire({
                type: 'Error',
                title: 'Üye Güncellenmedi ',
                text: 'Bir Sorun İle Karşılaşıldı...'
            });
        }

    });


});

//Üye İşlemleri Son




