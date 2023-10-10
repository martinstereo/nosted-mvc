# Use the official MariaDB image as the base image
FROM mariadb:latest

# Set environment variables (optional)
ENV MYSQL_ROOT_PASSWORD=12345
ENV MYSQL_DATABASE=webAppDatabase

# Copy your SQL initialization script into a directory inside the container
COPY CreateDb.sql /docker-entrypoint-initdb.d

# Optionally, you can include additional SQL scripts or configuration files
# COPY additional_script.sql /docker-entrypoint-initdb.d

# Expose the MySQL port (not required, as it's exposed by default)
# EXPOSE 3306