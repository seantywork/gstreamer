vorbis_sources = [
  'gstvorbis.c',
  'gstvorbiselement.c',
  'gstvorbisdec.c',
  'gstvorbisdeclib.c',
  'gstvorbisenc.c',
  'gstvorbisparse.c',
  'gstvorbistag.c',
  'gstvorbiscommon.c',
]

vorbis_headers = [
  'gstvorbiscommon.h',
  'gstvorbisdec.h',
  'gstvorbisdeclib.h',
  'gstvorbiselements.h',
  'gstvorbisenc.h',
  'gstvorbisparse.h',
  'gstvorbistag.h',
]

vorbisidec_sources = [
  'gstivorbisdec.c',
  'gstvorbiselement.c',
  'gstvorbisdec.c',
  'gstvorbisdeclib.c',
  'gstvorbiscommon.c',
]

vorbisidec_headers = [
  'gstvorbiscommon.h',
  'gstvorbisdec.h',
  'gstvorbisdeclib.h',
  'gstvorbiselements.h',
]

doc_sources = []
foreach s: vorbis_sources + vorbis_headers
  doc_sources += meson.current_source_dir() / s
endforeach

plugin_sources += {
  'vorbis': pathsep.join(doc_sources)
}

doc_sources = []
foreach s: vorbisidec_sources + vorbisidec_headers
  doc_sources += meson.current_source_dir() / s
endforeach

plugin_sources += {
  'ivorbisdec': pathsep.join(doc_sources)
}

vorbis_dep = dependency('vorbis', version : '>= 1.3.1', allow_fallback: true, required : get_option('vorbis'))
vorbisenc_dep = dependency('vorbisenc', version : '>= 1.3.1', allow_fallback: true, required : get_option('vorbis'))
vorbisidec_dep = dependency('vorbisidec', allow_fallback: true, required : get_option('tremor'))

if vorbis_dep.found()
  vorbis_deps = [vorbis_dep]
  if vorbisenc_dep.found()
    vorbis_deps += vorbisenc_dep
  endif
  gstvorbis = library('gstvorbis',
    vorbis_sources,
    c_args : gst_plugins_base_args,
    link_args : noseh_link_args,
    include_directories: [configinc, libsinc],
    dependencies : vorbis_deps + [audio_dep, tag_dep, gst_dep, gst_base_dep],
    install : true,
    install_dir : plugins_install_dir,
  )
  plugins += [gstvorbis]
endif

if vorbisidec_dep.found()
  # NOTE: This plugin is only useful if your device does not support hardware
  # floating point and needs integer ops for performance reasons.
  gstivorbisdec = library('gstivorbisdec',
    vorbisidec_sources,
    c_args : gst_plugins_base_args + ['-DTREMOR'],
    link_args : noseh_link_args,
    include_directories: [configinc, libsinc],
    dependencies : [vorbisidec_dep, audio_dep, tag_dep, gst_dep, gst_base_dep],
    install : true,
    install_dir : plugins_install_dir,
  )
  plugins += [gstivorbisdec]
endif
