<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1 style="color: #00ff21; text-align: center">Students</h1>
        <xsl:for-each select="/students/student">
          <h2>Student:</h2>
          <ul>
            <li>
              <span>Name: </span>
              <xsl:value-of select="name"/>
            </li>
            <li>
              <span>Gender: </span>
              <xsl:value-of select="gender"/>
            </li>
            <li>
              <span>Birth date: </span>
              <xsl:value-of select="birthDate"/>
            </li>
            <li>
              <span>Phone: </span>
              <xsl:value-of select="phone"/>
            </li>
            <li>
              <span>E-mail: </span>
              <xsl:value-of select="email"/>
            </li>
            <li>
              <span>University: </span>
              <xsl:value-of select="university"/>
            </li>
            <li>
              <span>Specialty: </span>
              <xsl:value-of select="specialty"/>
            </li>
            <li>
              <span>Faculty number: </span>
              <xsl:value-of select="facultyNumber"/>
            </li>
            <li>
              <span>Exams taken: </span>
              <xsl:for-each select="examsTaken/exam">
                <ul>
                  <span>Exam: </span>
                  <li>
                    <span>Name: </span>
                    <xsl:value-of select="name"/>
                  </li>
                  <li>
                    <span>Date: </span>
                    <xsl:value-of select="date"/>
                  </li>
                  <li>
                    <span>Grade: </span>
                    <xsl:value-of select="grade"/>
                  </li>
                </ul>
              </xsl:for-each>
            </li>
            <li>
              <span>Endorsements: </span>
              <ul>
                <li>
                  <span>author:</span>
                  <xsl:value-of select="Endorsements/author"/>
                </li>
                <li>
                  <span>Email</span>
                  <xsl:value-of select="Endorsements/email"/>
                </li>
              </ul>
            </li>
            <li>
              <span>Date: </span>
              <xsl:value-of select="date"/>
            </li>
            <li>
              <span>Text: </span>
              <xsl:value-of select="text"/>
            </li>
          </ul>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>