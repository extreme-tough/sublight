Imports System.CodeDom.Compiler
Imports System.Xml.Serialization

Namespace Sublight.WS_SublightClient

    <System.Serializable, _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927"), _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/")> _
    Public Enum PaymentType
        Unknown
        PayPalDonation
        ContributionTranslation
        ContributionOther
        PayPal
    End Enum

End Namespace

