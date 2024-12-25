# FastNotes - A Command-Line Note-Taking App

FastNotes is a simple and efficient note-taking application designed to work directly from the terminal. It allows users to quickly create, view, and manage notes without ever leaving their command-line environment.

## Features

- Create, view, edit, and delete notes directly from the terminal.
- Restore deleted notes from the fastNotes trash

## Installation

### Prerequisites

- **Operating System**: Compatible with Linux.
- **Dependencies**: No need for any dependency.

### Install with the one-liner script

Please be careful of what you are instaling with this type of installation.

To install fastNotes, run one of the following command:

With `curl`

```bash
curl -fsSL https://raw.githubusercontent.com/theophileTheKing/FastNotes/refs/heads/main/install.sh | sudo bash
```

Or with `wget`

```bash
wget -qO- https://raw.githubusercontent.com/theophileTheKing/FastNotes/refs/heads/main/install.sh | sudo bash
```

### Build yourself (need dotnet 9 installed)

1. **Clone the Repository**:

```bash
git clone https://github.com/theophileTheKing/FastNotes
cd FastNotes
```

2. **Publish the executable for linux**:

```bash
dotnet publish -c Release -r linux-x64 --self-contained true /p:PublishSingleFile=true
```

3. **Make the app directory**:

```bash
mkdir -p /opt/fastNotes
```

4. **Move the executable to `/opt/fastNotes`**:

```bash
cp bin/Release/net9.0/linux-x64/publish/FastNotes /opt/fastNotes
```

5. **Move the fn script to `/usr/local/bin`**:

```bash
mv fn /usr/local/bin
```

6. **Try to start fastNotes**:

```bash
fn
```

## Run the Application

To start the application, use the following command:

```bash
fn
```

## Print the help message

```bash
help
```

## Contributing

Any contribution is welcome ! Take a look at the [CONTRIBUTING.md](CONTRIBUTING.md) file

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

---

Start taking notes directly from your terminal today with fastNotes !
