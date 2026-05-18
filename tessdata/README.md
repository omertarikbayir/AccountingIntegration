# Tesseract Tessdata Setup

This folder should contain Tesseract language data files.

## How to download:

1. Go to: https://github.com/tesseract-ocr/tessdata
2. Download the required files:
   - `tur.traineddata` (Turkish)
   - `eng.traineddata` (English)
3. Copy them into this `tessdata` folder.

## For production:

You can also set the path via environment variable:
`TESSERACT_DATA_PATH=/path/to/tessdata`

The application looks for tessdata in the output directory by default.