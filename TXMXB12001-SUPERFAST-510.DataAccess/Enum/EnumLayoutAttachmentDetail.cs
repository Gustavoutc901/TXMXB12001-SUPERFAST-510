using System;
using System.Collections.Generic;
using System.Text;

namespace TXMXB12001_SUPERFAST_510
{
    public enum EnumLayoutAttachmentDetail
    {
        [File510PointsAttribute(2, 0, 6)]
        [File510MapValidationAttribute("ValidationRequirement", true)]
        NoAutorizacion,

        [File510PointsAttribute(2, 6, 25)]
        [File510MapValidationAttribute("ValidationRequirement", false)]
        NoCuenta,

        [File510PointsAttribute(2, 25, 27)]
        [File510MapValidationAttribute("None")]
        TipoRegistro,

        [File510PointsAttribute(2, 27, 43)]
        [File510MapValidationAttribute("None")]
        ApplicationC,

        [File510PointsAttribute(2, 43, 45)]
        [File510MapValidationAttribute("None")]
        Cryptogram,

        [File510PointsAttribute(2, 45, 109)]
        [File510MapValidationAttribute("None")]
        IssuerAD,

        [File510PointsAttribute(2, 109, 117)]
        [File510MapValidationAttribute("None")]
        UnpredictableNumber,

        [File510PointsAttribute(2, 117, 121)]
        [File510MapValidationAttribute("None")]
        AplicationTransactionCounter,

        [File510PointsAttribute(2, 121, 131)]
        [File510MapValidationAttribute("None")]
        TerminalVerificationResult,

        [File510PointsAttribute(2, 131, 137)]
        [File510MapValidationAttribute("None")]
        TransactionDate,

        [File510PointsAttribute(2, 137, 139)]
        [File510MapValidationAttribute("None")]
        TransactionType,

        [File510PointsAttribute(2, 139, 151)]
        [File510MapValidationAttribute("None")]
        AmountAuthorized,

        [File510PointsAttribute(2, 151, 155)]
        [File510MapValidationAttribute("None")]
        TransactionCurrencyCode,

        [File510PointsAttribute(2, 155, 159)]
        [File510MapValidationAttribute("None")]
        ApplicationInterchangeProfile,

        [File510PointsAttribute(2, 159, 163)]
        [File510MapValidationAttribute("None")]
        TerminalCountryCode,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 163, 175)]
        AmountOther,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 175, 181)]
        CardholderVerificationMethod,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 181, 189)]
        TeminalCapabilities,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 189, 191)]
        TerminalType,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 191, 199)]
        InterfaceDeviceSerialNumber,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 199, 231)]
        DedicatedFileName,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 231, 235)]
        TerminalApplicationVersionNumber,

        [File510MapValidationAttribute("None")]
        [File510PointsAttribute(2, 235, 267)]
        IssuerAuthenticationData,



    }
}
