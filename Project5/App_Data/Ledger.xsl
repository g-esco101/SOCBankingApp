<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
	<xsl:template match="/">
		<html>  <body>
			<h3>Transactions</h3>
			<table border="1">
				<tr bgcolor="black" style="color: gray" > 
					<td><b>Account Number</b></td> 
					<td><b>Account Nickname</b></td> 
					<td><b>Owner</b></td> 
					<td><b>Transaction Type</b></td> 
					<td><b>Destination Account</b></td>
					<td><b>Amount</b></td> 
					<td><b>Balance</b></td> 
					<td><b>Date</b></td>
          <td><b>Time</b></td>
				</tr>
				<xsl:for-each select="Transactions/Transaction">
					<xsl:sort select="Date" order="descending"/>
          <xsl:sort select="Time" order="descending"/>
					<tr style="font-size: 10pt; font-family: verdana;">
						<td><xsl:value-of select="AccountNumber"/></td>
						<td><xsl:value-of select="Nickname"/></td>
						<td><xsl:value-of select="Owner"/></td>
						<td><xsl:value-of select="TransactionType"/></td>
						<td><xsl:value-of select="TransactionType/@AssociatedAccount"/></td>
						<td><xsl:value-of select="Amount"/></td>
						<td><xsl:value-of select="Balance"/></td>
						<td><xsl:value-of select="Date"/></td>
           <td><xsl:value-of select="Time"/></td>
					</tr>
				</xsl:for-each>
			</table>
		</body> </html>
	</xsl:template>
</xsl:stylesheet>