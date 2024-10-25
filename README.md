# SimpleTwitter

## Overview
**SimpleTwitter** is a microblogging web application that enables users to share and view comments in a Twitter-like feed. Each post comments is limited to 140 characters, and users must be registered and logged in to interact with posts and comments. SimpleTwitter showcases a full-stack development approach with server-side and client-side technologies, database management, and essential validations to ensure data integrity and quality.

## Features
- **User Registration & Login**: Only registered users can post comments or interact with posts.
- **Post Tweets**: Authenticated users can post short comments (tweets) with a maximum length of 140 characters.
- **Comment on Tweets**: Users can comment on any post, and these comments are visible to all other users.
- **Feed Display**: Posts and comments are displayed in reverse chronological order.
- **Validation**: Ensures that only valid data is submitted to the database, such as non-empty usernames and comments under 140 characters.

## Technologies Used
- **Backend**: C# with ASP.NET Core
- **Frontend**: React.js
- **Database**: SQL Server
- **Testing**: Unit tests for validation and core functionality

## Requirements
- **C#/.NET** for server-side functionality
- **React** for building the user interface
- **SQL Server** for data storage

## Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/your-username/SimpleTwitter.git
   cd SimpleTwitter

2. **Backend Setup**:
   - Ensure you have .NET SDK installed.
   - Navigate to the backend project folder and restore dependencies:
     ```bash
     dotnet restore
     ```
   - Update the `appsettings.json` file with your SQL Server connection string.

3. **Frontend Setup**:
   - Ensure Node.js is installed.
   - Navigate to the frontend folder and install dependencies:
     ```bash
     npm install
     ```

4. **Database Setup**:
   - Run the necessary SQL migrations to set up the database schema.

5. **Run the Application**:
   - Start the backend server:
     ```bash
     dotnet run
     ```
   - Start the frontend development server:
     ```bash
     npm start
     ```

## Usage
- **Register**: Sign up with a unique username and password.
- **Log In**: Access your account by logging in with valid credentials.
- **Post a Tweet**: Share a tweet with a maximum of 140 characters.
- **Comment on Tweets**: Interact with other users by commenting on their tweets.
- **View Feed**: See the latest tweets and comments, updated in real-time.
  
## Testing

Unit tests have been implemented for core features, including:

- User registration and login validation
- Posting tweets with character limits
- Commenting functionality
