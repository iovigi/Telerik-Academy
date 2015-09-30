<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

  <xsl:template match="/">
    <html>
      <head>
        <title> Students</title>
      </head>
      <body>
        <table border="1">
          <tr>
            <td>Student</td>
            <td>Gender</td>
            <td>Birth Date</td>
            <td>Phone</td>
            <td>E-mail</td>
            <td>Course</td>
            <td>Specialty</td>
            <td>Faculty #</td>
            <td>Exams</td>
          </tr>
          <xsl:for-each select="students/student">
            <tr>
              <td>
                <xsl:value-of select="name" />
              </td>
              <td>
                <xsl:value-of select="sex" />
              </td>
              <td>
                <xsl:value-of select="birthDate" />
              </td>
              <td>
                <xsl:value-of select="phone" />
              </td>
              <td>
                <xsl:value-of select="email" />
              </td>
              <td>
                <xsl:value-of select="course" />
              </td>
              <td>
                <xsl:value-of select="specialty" />
              </td>
              <td>
                <xsl:value-of select="facultyNumber" />
              </td>
              <td>
                <xsl:for-each select="takenExams/exam">
                      <xsl:value-of select="name"/> 
                    tutor: <xsl:value-of select="tutor"/> 
                    score: <xsl:value-of select="score"/>
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>