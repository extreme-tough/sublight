Imports System.CodeDom.Compiler
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927")> _
    Public Enum SubtitleType
        Unknown
        Sub
        Srt
        SubViewer2
        SAMI
    End Enum

End Namespace

