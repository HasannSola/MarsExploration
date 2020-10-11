angular.module("AppModule", ["HelperService", "CoreService"])
    .controller("homeCtrl", function ($scope, helperSrv, MarsEnum, coreSrv) {
        $scope.customerPopup = function () {
            $("input[Name=StName]").val("");
            $("input[Name=InCustomerId]").val(0);
            $("textarea[Name=StDescription]").val("");
            $("input[Name=FlBalance]").val(0);
        };

        $("#locationAddBtn").click(function () {
            var formData = helperSrv.convertFormJson($('#homeFormId').serializeArray());
            if (isControl(formData)) {//View gelen dataların kontrol edilmesi
                var xyStartCordinant = formData.StStartXY.split(',');
                var xyCordinant = formData.StMarsXY.split(',');
                var saveObject = {
                    stMarsX: Number(xyCordinant[0]),//X
                    stMarsY: Number(xyCordinant[1]),//Y
                    stStartX: Number(xyStartCordinant[0]),//X
                    stStartY: Number(xyStartCordinant[1]),//Y
                    stPosition: formData.StPosition,
                    stCommand: formData.StCommand
                };
                coreSrv.create(saveObject, '/home/CreateLocation').then(function (result) {
                    if (result.success) {
                        $scope.locationResult = result.data;
                    }
                }, function (error) { });
            }
        });

        function isControl(formData) {
            var result = false;
            var xyStartCordinant = formData.StStartXY.split(',');
            var xyCordinant = formData.StMarsXY.split(',');
            var Commands = formData.StCommand;
            var oldCommnd = formData.StCommand.toUpperCase();
            formData.StCommand = formData.StCommand.toUpperCase();
            formData.StCommand = formData.StCommand.replace(/[^LMR]/g, '');

            if (!helperSrv.isNotEmpty(formData.StMarsXY)) {
                helperSrv.notification("Lütfen Mars Koordinat Giriniz.", "Uyarı", MarsEnum.NotificaitonType[3]);
            }
            else if (!helperSrv.isNotEmpty(formData.StStartXY)) {
                helperSrv.notification("Lütfen Başlangıç koordiant Giriniz.", "Uyarı", MarsEnum.NotificaitonType[3]);
            }
            else if (!helperSrv.isNotEmpty(formData.StPosition) || formData.StPosition === 0) {
                helperSrv.notification("Lütfen Yön Seçiniz Giriniz.", "Uyarı", MarsEnum.NotificaitonType[3]);
            }
            else if (oldCommnd !== formData.StCommand) {
                oldCommnd = oldCommnd.replaceAll("L","");
                oldCommnd = oldCommnd.replaceAll("R","");
                oldCommnd = oldCommnd.replaceAll("M","");
                helperSrv.notification("Yanlış Komut < " + oldCommnd+" >  Girdiniz.", "Uyarı", MarsEnum.NotificaitonType[3]);
            }
            else if (!helperSrv.isNotEmpty(formData.StCommand) || formData.StCommand > 1) {
                helperSrv.notification("Lütfen Komut  Giriniz.", "Uyarı", MarsEnum.NotificaitonType[3]);
            }

            else if (xyCordinant[0] <0 || xyCordinant[1] < 0) {
                helperSrv.notification("Lütfen Mars Koordinat Uygun formata giriniz.", "Uyarı", MarsEnum.NotificaitonType[4]);
            }

            else if (xyStartCordinant[0] < 0 || xyStartCordinant[1] < 0) {
                helperSrv.notification("Lütfen Başlangıç Koordinat Uygun formata giriniz.", "Uyarı", MarsEnum.NotificaitonType[4]);
            } else {
                result = true;
            }
            return result;
        }
    });
