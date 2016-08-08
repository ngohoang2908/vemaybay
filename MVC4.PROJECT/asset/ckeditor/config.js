/**
 * @license Copyright (c) 2003-2015, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';

    config.language = 'vi';
    config.enterMode = CKEDITOR.ENTER_BR;//không tạo ra thẻ p khi nhập.
    config.filebrowserBrowseUrl = '/asset/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/asset/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/asset/ckfinder/ckfinder.html?Type=Flash';
    config.filebrowserUploadUrl = '/asset/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
    config.filebrowserFlashUploadUrl = '/asset/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
    config.allowedContent = true;
    config.filebrowserImageUploadUrl = '/content/upload';
    config.extraAllowedContent = 'p(*)[*]{*};div(*)[*]{*};li(*)[*]{*};ul(*)[*]{*}';

    CKFinder.setupCKEditor(null, '/asset/ckfinder/');
};
