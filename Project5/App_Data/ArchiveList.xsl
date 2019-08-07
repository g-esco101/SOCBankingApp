<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<h3>Archived Files</h3>
			<table border="1">
				<tr bgcolor="black" style="color: gray" > 
					<td><b>Name</b></td> 
					<td><b>ArchivedName</b></td> 
					<td><b>Date</b></td> 
					<td><b>Time</b></td> 
				</tr>
				<xsl:for-each select="Files/File">
					<xsl:sort select="Date" order="descending"/>
          <xsl:sort select="Time" order="descending"/>
					<tr style="font-size: 10pt; font-family: verdana;">
						<td><xsl:value-of select="Name"/></td>
            <td><xsl:value-of select="ArchivedName"/></td>
						<td><xsl:value-of select="Date"/></td>
						<td><xsl:value-of select="Time"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>