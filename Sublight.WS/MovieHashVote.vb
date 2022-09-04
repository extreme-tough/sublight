Imports System.CodeDom.Compiler
Imports System.Xml.Serialization

Namespace Sublight.WS

    <System.Serializable, _
    System.Xml.Serialization.XmlType(Namespace = "http://www.sublight.si/"), _
    System.CodeDom.Compiler.GeneratedCode("System.Xml", "2.0.50727.4927")> _
    Public Enum MovieHashVote
        OK
        WrongMovie
        WrongSeasonEpisode
    End Enum

End Namespace

