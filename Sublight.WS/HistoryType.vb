Imports System
Imports System.CodeDom.Compiler
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.Flags, _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927")> _
    Public Enum HistoryType
        None = 1
        Published = 2
        StatusChanged = 4
        StatusChangedDeleted = 8
        StatusChangedAuthorized = 16
        SubtitleUpdated = 32
        ImdbUpdated = 64
    End Enum

End Namespace

