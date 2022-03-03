using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510
{
    public enum EnumLayoutDetail
    {
        [File510PointsAttribute(1, 0, 5)]
        [File510MapValidationAttribute("ValidationLong", true)]
        Bancoemisor,

        [File510PointsAttribute(1, 5, 24)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        NoCuenta,

        [File510PointsAttribute(1, 24, 25)]
        //[File510MapValidationAttribute("ValidationContains", "C,D", false)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        NaturalezaContable,

        [File510PointsAttribute(1, 25, 26)]
        //[File510MapValidationAttribute("ValidationContains", "1,2,3", false)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        MarcaProducto,

        [File510PointsAttribute(1, 28, 34)]
        [File510MapValidationAttribute("ValidationDate", true)]
        FechaConsumo,

        [File510PointsAttribute(1, 34, 40)]
        [File510MapValidationAttribute("ValidationTime", false)]
        HoraConsumo,

        [File510PointsAttribute(1, 40, 46)]
        [File510MapValidationAttribute("ValidationDate", true)]
        FechaProceso,

        [File510PointsAttribute(1, 46, 48)]
        [File510MapValidationAttribute("ValidationLong", true)]
        //[File510MapValidationAttribute("ValidationContainsLong", "1,20,18,21")]
        TipoTransaccion,

        [File510PointsAttribute(1, 48, 50)]
        [File510MapValidationAttribute("ValidationLong", true)]
        NumeroLiquidacion,

        [File510PointsAttribute(1, 50, 63)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteOrigenTotal,

        [File510PointsAttribute(1, 63, 76)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteOrigenConsumo,

        [File510PointsAttribute(1, 76, 79)]
        [File510MapValidationAttribute("ValidationLong", true)]
        ClaveMonedaImporteOrigen,

        [File510PointsAttribute(1, 79, 92)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteDestinoTotal,

        [File510PointsAttribute(1, 92, 105)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteDestinoConsumo,

        [File510PointsAttribute(1, 105, 108)]
        [File510MapValidationAttribute("ValidationLong", true)]
        ClaveMonedaDestino,

        [File510PointsAttribute(1, 108, 115)]
        [File510MapValidationAttribute("ValidationDecimal", true, 3, 4)]
        ParidadDestino,

        [File510PointsAttribute(1, 115, 128)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteLiquidacionTotal,

        [File510PointsAttribute(1, 128, 141)]
        [File510MapValidationAttribute("ValidationDecimal", true, 11, 2)]
        ImporteLiquidacionConsumo,

        [File510PointsAttribute(1, 141, 144)]
        [File510MapValidationAttribute("ValidationLong", true)]
        ClaveMonedaLiquidacion,

        [File510PointsAttribute(1, 144, 151)]
        [File510MapValidationAttribute("ValidationDecimal", true, 3, 4)]
        ParidadLiquidacion,

        [File510PointsAttribute(1, 151, 168)]
        [File510MapValidationAttribute("ValidationDecimal", false, 11, 6)]
        ImporteCuotaIntercambio,

        [File510PointsAttribute(1, 168, 185)]
        [File510MapValidationAttribute("ValidationDecimal", false, 11, 6)]
        IvaCuotaIntercambio,

        [File510PointsAttribute(1, 185, 198)]
        [File510MapValidationAttribute("ValidationDecimal", false, 11, 2)]
        ImporteCalculadoParaAplicacionTH,

        [File510PointsAttribute(1, 198, 211)]
        [File510MapValidationAttribute("ValidationDecimal", false, 11, 2)]
        ImporteCalculadoAplicacionTH,

        [File510PointsAttribute(1, 211, 216)]
        [File510MapValidationAttribute("ValidationDecimal", false, 3, 2)]
        PorcentajeComisionAplicacionTH,
        //MAPM 31-MAY
        [File510PointsAttribute(1, 221, 242)]
        [File510MapValidationAttribute("None")]
        DescrpEstado,

        [File510PointsAttribute(1, 242, 257)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        Clavecomercio,

        [File510PointsAttribute(1, 257, 262)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        MccoGiroComercio,

        [File510PointsAttribute(1, 262, 292)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        NombreComercio,

        [File510PointsAttribute(1, 292, 332)]
        [File510MapValidationAttribute("None")]
        DireccionComercio,

        [File510PointsAttribute(1, 332, 335)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        PaisOrigenTX,

        [File510PointsAttribute(1, 335, 345)]
        [File510MapValidationAttribute("None")]
        CodigoPostal,

        [File510PointsAttribute(1, 345, 358)]
        [File510MapValidationAttribute("None")]
        PoblacionComercio,

        [File510PointsAttribute(1, 358, 363)]
        [File510MapValidationAttribute("ValidationDecimal", true, 3, 2)]
        PorcentajeCuotaIntercambio,

        [File510PointsAttribute(1, 363, 365)]
        //[File510MapValidationAttribute("ValidationRequirement", false)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        FamiliaComercio,

        [File510PointsAttribute(1, 365, 378)]
        //[File510MapValidationAttribute("ValidationRequirement", false)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        RFCComercio,

        [File510PointsAttribute(1, 378, 380)]
        //[File510MapValidationAttribute("ValidationRequirement", false)]//SE CAMBIO POR SOLICITUD DE JC 18-ABRIL-2020
        [File510MapValidationAttribute("ValidationContains", "", true)]
        EstatusComercio,

        [File510PointsAttribute(1, 380, 385)]
        [File510MapValidationAttribute("ValidationLong", true)]
        NumeroFuente,

        [File510PointsAttribute(1, 385, 391)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        NumeroAutorizacion,

        [File510PointsAttribute(1, 391, 396)]
        [File510MapValidationAttribute("ValidationLong", true)]
        BancoReceptor,

        [File510PointsAttribute(1, 396, 419)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        ReferenciaTransaccion,

        [File510PointsAttribute(1, 419, 420)]
        //[File510MapValidationAttribute("ValidationContainsLong", "0,1,2,3,4,5,6,9")]
        [File510MapValidationAttribute("ValidationLong", true)]
        ModoAutorizacion,

        [File510PointsAttribute(1, 420, 422)]
        //[File510MapValidationAttribute("ValidationContains", "00,01,02,03,04,09,14,17,18,19,20,22", false)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        IndicadorMedioAcceso,

        [File510PointsAttribute(1, 422, 424)]
        //[File510MapValidationAttribute("ValidationLong", true)]
        [File510MapValidationAttribute("ValidationLong", true)]
        PagosDiferidos,

        [File510PointsAttribute(1, 424, 426)]
        //[File510MapValidationAttribute("ValidationLong", true)]
        [File510MapValidationAttribute("ValidationLong", true)]
        PagosDiferidosParcializacion,

        [File510PointsAttribute(1, 426, 428)]
        //[File510MapValidationAttribute("ValidationContainsLong", "0,3,5,7,13,15,17")]
        [File510MapValidationAttribute("ValidationLong", true)]
        PagosDiferidosTipoPlan,

        [File510PointsAttribute(1, 428, 436)]
        [File510MapValidationAttribute("ValidationDecimal", false, 6, 2)]
        Sobretasa,

        [File510PointsAttribute(1, 436, 443)]
        [File510MapValidationAttribute("ValidationDecimal", false, 5, 2)]
        IvaSobretasa,

        [File510PointsAttribute(1, 443, 448)]
        [File510MapValidationAttribute("ValidationDecimal", false, 3, 2)]
        PorcentajeSobreTasa,

        [File510PointsAttribute(1, 448, 449)]
        //[File510MapValidationAttribute("ValidationContainsLong", "0,1")]
        [File510MapValidationAttribute("ValidationLong", true)]
        PagosDiferidosIndicadorCobroA,

        [File510PointsAttribute(1, 449, 453)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        FiidEmisor,

        [File510PointsAttribute(1, 464, 465)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        //[File510MapValidationAttribute("ValidationContains", "Y,N", true)]
        ComercioElectroniCoidct,

        [File510PointsAttribute(1, 465, 466)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        //[File510MapValidationAttribute("ValidationContains", "0,5,6,7,8", false)]
        ComercioElectronicoIce,

        [File510PointsAttribute(1, 466, 467)]
        [File510MapValidationAttribute("None")]
        //[File510MapValidationAttribute("ValidationContains", "0,1,2", true)]
        AuthenticationCollectorIndicator,

        [File510PointsAttribute(1, 467, 468)]
        //[File510MapValidationAttribute("ValidationContains", "0,1,2,3,4,5,8,9", true)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        ComercioElectronicoTc,

        [File510PointsAttribute(1, 468, 469)]
        //[File510MapValidationAttribute("ValidationRequirement", true)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        ComercioElectronicoIta,

        [File510PointsAttribute(1, 469, 479)]
        //[File510MapValidationAttribute("ValidationContains", "", true)]
        [File510MapValidationAttribute("None")]
        ComercioElectronicoTid,

        [File510PointsAttribute(1, 479, 481)]
        //[File510MapValidationAttribute("ValidationContainsLong", "0,1,4,5,7,80,81,90,91")]
        [File510MapValidationAttribute("ValidationLong", false)]
        PosentryMode,

        [File510PointsAttribute(1, 481, 482)]
        //[File510MapValidationAttribute("ValidationContains", "0,1,2,9", true)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        IndicadorCV2,

        [File510PointsAttribute(1, 482, 483)]
        //[File510MapValidationAttribute("ValidationContains", "0,1,2,3,4,5,6,7", true)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        ComercioElectronicoIcavv,

        [File510PointsAttribute(1, 483, 487)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        FiidAdquiriente,

        [File510PointsAttribute(1, 487, 488)]
        //[File510MapValidationAttribute("ValidationContains", "0,1", false)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        IndicadorPagoInterbancario,

        [File510PointsAttribute(1, 488, 489)]
        //[File510MapValidationAttribute("ValidationContains", "A,B,C", true)]
        [File510MapValidationAttribute("ValidationContains", "", true)]
        ServiceCode
    }
}
