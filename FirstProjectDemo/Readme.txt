project-firstprojectdemo
Database Work-

		Tbl_User-
				id-pk-identity
				fname
				lname
				email
				password
				gender
				profile_image
				isactive-bit
				isverified-bit
				created_on
				updated_on

----------------------------------------------------------------------------------------------------

Tbl_VerifyAccount-
					id
					otp
					userid
					sendtime

-----------------------------------------------------------------------------------------------------
Tbl_Category-
				id
				name
				description
				image

-----------------------------------------------------------------------------------------------------

Tbl_products-
				id
				title
				price
				quantity
				description
				cat_id-fk

------------------------------------------------------------------------------------------------------

Tbl_product-images-
						id
						image_url
						product_id
						image_type

------------------------------------------------------------------------------------------------------

